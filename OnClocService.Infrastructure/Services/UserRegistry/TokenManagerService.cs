using Microsoft.AspNetCore.Authentication;
using OnClocService.Core.Entities.Systems;
using OnClocService.Domain.DataModels.Systems;
using OnClocService.Domain.Interfaces.UserRegistry;
using OnClocService.Domain.Responses.UserRegistry;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace OnClocService.Infrastructure.Services.UserRegistry;

public class TokenManagerService(ITokenManagerService tokenManager)
{
    public async Task<AuthenticationTicket> GetAuthenticationTicketAsync(ClaimsPrincipal principal) => await tokenManager.GenerateAuthenticationTicketAsync(principal);
    public async Task<AuthenticationTicket> RefreshAuthenticationTicketAsync(AuthenticationTicket ticket) => await tokenManager.UpdateAuthenticationTicketAsync(ticket);
    public RefreshResponse GetRefreshToken() => tokenManager.GenerateRefreshToken();
    public async Task<JwtSecurityToken> GetAccessTokenAsync(CurrentUser user, IList<Claim> userClaims) => await tokenManager.GenerateJwtTokenAsync(user, userClaims);
    public async Task<SystemsRefreshToken> RetrieveActiveRefreshTokenAsync(string email) => await tokenManager.GetActiveSystemsUserRefreshTokenAsync(email);
    public async Task SaveRefreshTokenAsync(SystemsRefreshToken userRefreshToken) => await tokenManager.AddUserRefreshTokenAsync(userRefreshToken);
    public async Task RevokeRefreshTokenAsync(SystemsRefreshToken userRefreshToken) => await tokenManager.RevokeUserRefreshTokenAsync(userRefreshToken);
    public Task<ClaimsPrincipal> GetPrincipalFromTokenAsync(string expiredAccessToken) => tokenManager.GetPrincipalFromExpiredTokenAsync(expiredAccessToken);
}