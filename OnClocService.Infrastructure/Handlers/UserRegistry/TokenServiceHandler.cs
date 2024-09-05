#nullable disable

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OnClocService.Core.Entities.Systems;
using OnClocService.Core.Entities.UserRegistry;
using OnClocService.Domain.DataModels.Systems;
using OnClocService.Domain.Interfaces.UserRegistry;
using OnClocService.Domain.Responses.UserRegistry;
using OnClocService.Infrastructure.DataStorage;
using OnClocService.Infrastructure.Services.Systems;
using OnClocService.Infrastructure.Services.UserRegistry;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace OnClocService.Infrastructure.Handlers.UserRegistry;

internal class TokenServiceHandler(
    OnClocDataStorageContext storageContext, 
    JwtOptionsService jwtOptionsService,
    UserManager<SystemsUser> userManager, 
    UserContextService userContext) : ITokenManagerService
{
    private readonly OnClocDataStorageContext _StorageContext = storageContext;
    private readonly JwtOptionsService _JwtOptionsService = jwtOptionsService;
    private readonly UserManager<SystemsUser> _UserManager = userManager;
    private readonly UserContextService _UserContext = userContext;
    private const string ACCESS_KEY = nameof(ACCESS_KEY);
    private const string REFRESH_KEY = nameof(REFRESH_KEY);
    private const string REFRESH_EXP = nameof(REFRESH_EXP);
    private const int MaxRefreshTokens = 5;

    public async Task<AuthenticationTicket> GenerateAuthenticationTicketAsync(ClaimsPrincipal principal)
    {
        var user = await _UserManager.GetUserAsync(principal) ?? throw new InvalidOperationException("principal is not present");
        var userWithRoles = _UserContext.GetUser(principal);
        var userClaims = await _UserManager.GetClaimsAsync(user);
        var jwtToken = await GenerateJwtTokenAsync(userWithRoles, userClaims);
        var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
        var refreshToken = GenerateRefreshToken();
        // Create Authentication Tokens
        IEnumerable<AuthenticationToken> authenticationTokens =
            [
                 new() { Name = ACCESS_KEY, Value = accessToken },
                 new() { Name = REFRESH_KEY, Value = refreshToken.Token }
            ];
        // Create Authenication Ticket
        var authenticationScheme = JwtBearerDefaults.AuthenticationScheme;
        var ticket = new AuthenticationTicket(principal, authenticationScheme);
        ticket.Properties.AllowRefresh = true;
        ticket.Properties.StoreTokens(authenticationTokens);
        ticket.Properties.IssuedUtc = DateTime.SpecifyKind(jwtToken.ValidFrom, DateTimeKind.Utc);
        ticket.Properties.ExpiresUtc = DateTime.SpecifyKind(jwtToken.ValidTo, DateTimeKind.Utc);
        ticket.Properties.IsPersistent = true;
        ticket.Properties.SetParameter(REFRESH_EXP, refreshToken.Expiry);
        return ticket;
    }

    public async Task<AuthenticationTicket> UpdateAuthenticationTicketAsync(AuthenticationTicket ticket)
    {
        var user = await _UserManager.GetUserAsync(ticket.Principal) ?? throw new InvalidOperationException("principal is not present");
        var userWithRoles = _UserContext.GetUser(ticket.Principal);
        var userClaims = await _UserManager.GetClaimsAsync(user);
        var jwtToken = await GenerateJwtTokenAsync(userWithRoles, userClaims);
        var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
        ticket.Properties.UpdateTokenValue(ACCESS_KEY, accessToken);
        ticket.Properties.IssuedUtc = DateTime.SpecifyKind(jwtToken.ValidFrom, DateTimeKind.Utc);
        ticket.Properties.ExpiresUtc = DateTime.SpecifyKind(jwtToken.ValidTo, DateTimeKind.Utc);
        return ticket;
    }

    public async Task<ClaimsPrincipal> GetPrincipalFromExpiredTokenAsync(string expiredAccessToken)
    {
        var key = Encoding.UTF8.GetBytes(await _JwtOptionsService.GetKey());
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ClockSkew = TimeSpan.Zero
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var principal = tokenHandler.ValidateToken(expiredAccessToken, tokenValidationParameters, out SecurityToken securityToken);
        if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            throw new SecurityTokenException("invalid access token");
        return principal;
    }

    public async Task<JwtSecurityToken> GenerateJwtTokenAsync(CurrentUser user, IList<Claim> userClaims)
    {
        var roleClaims = new List<Claim>();
        IEnumerable<string> roles = user.Roles;
        foreach (var role in roles)
        {
            roleClaims.Add(new Claim("role", role));
        }
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email!),
            new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString())
        }
        .Union(userClaims)
        .Union(roleClaims);

        var key = Encoding.UTF8.GetBytes(await _JwtOptionsService.GetKey());
        var symmetricSecurityKey = new SymmetricSecurityKey(key);
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
        var tokenDuration = await _JwtOptionsService.GetDurationMinutes();

        var jwtSecurityToken = new JwtSecurityToken(
            issuer: await _JwtOptionsService.GetIssuer(),
            audience: await _JwtOptionsService.GetAudience(),
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: DateTime.UtcNow.AddMinutes(tokenDuration),
            signingCredentials: signingCredentials);

        return jwtSecurityToken;
    }

    public RefreshResponse GenerateRefreshToken()
    {
        var randomNumber = new byte[64];
        using var generator = RandomNumberGenerator.Create();
        generator.GetBytes(randomNumber);
        var refreshToken = new RefreshResponse()
        {
            Token = Convert.ToBase64String(randomNumber),
            Expiry = DateTimeOffset.UtcNow.AddHours(12)
        };
        return refreshToken;
    }

    public async Task AddUserRefreshTokenAsync(SystemsRefreshToken userRefreshToken)
    {
        await ClearRevokedRefreshTokens(userRefreshToken.UserName);
        _StorageContext.SystemsRefreshTokens.Add(userRefreshToken);
        await _StorageContext.SaveChangesAsync();
    }

    private async Task ClearRevokedRefreshTokens(string email)
    {
        
        var allRefreshTokens = await GetAllUserRefreshTokensAsync(email);
        if (allRefreshTokens.Count > MaxRefreshTokens)
        {
            int itemCount = allRefreshTokens.Count;
            int startIndex = allRefreshTokens.Count - 1;

            for (int i = itemCount; i > MaxRefreshTokens; i--)
            {
                _StorageContext.SystemsRefreshTokens.Remove(allRefreshTokens[startIndex]);
                startIndex--;
            }
            await _StorageContext.SaveChangesAsync();
        }
    }

    public async Task RevokeUserRefreshTokenAsync(SystemsRefreshToken userRefreshToken)
    {
        userRefreshToken.Revoked = DateTimeOffset.UtcNow;
        _StorageContext.SystemsRefreshTokens.Update(userRefreshToken);
        await _StorageContext.SaveChangesAsync();
    }

    public async Task<SystemsRefreshToken> GetActiveSystemsUserRefreshTokenAsync(string email)
    {
        var refreshTokens = await GetAllUserRefreshTokensAsync(email);
        if (refreshTokens.Count > 0)
        {
            var activeRefreshToken = refreshTokens.FirstOrDefault(x => x.IsActive == true);
            return activeRefreshToken!;
        }
        return null;
    }

    public async Task<List<SystemsRefreshToken>> GetAllUserRefreshTokensAsync(string email)
        => await _StorageContext.SystemsRefreshTokens.Where(u => u.UserName == email).OrderByDescending(x => x.Created).ToListAsync();
}

