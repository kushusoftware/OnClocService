using Microsoft.AspNetCore.Authentication;
using OnClocService.Core.Entities.Systems;
using OnClocService.Domain.DataModels.Systems;
using OnClocService.Domain.Responses.UserRegistry;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace OnClocService.Domain.Interfaces.UserRegistry
{
    public interface ITokenManagerService
    {
        Task<AuthenticationTicket> GenerateAuthenticationTicketAsync(ClaimsPrincipal principal);
        Task<AuthenticationTicket> UpdateAuthenticationTicketAsync(AuthenticationTicket ticket);
        RefreshResponse GenerateRefreshToken();
        Task AddUserRefreshTokenAsync(SystemsRefreshToken userRefreshToken);
        Task RevokeUserRefreshTokenAsync(SystemsRefreshToken userRefreshToken);
        Task<JwtSecurityToken> GenerateJwtTokenAsync(CurrentUser user, IList<Claim> userClaims);
        Task<ClaimsPrincipal> GetPrincipalFromExpiredTokenAsync(string expiredAccessToken);
        Task<List<SystemsRefreshToken>> GetAllUserRefreshTokensAsync(string email);
        Task<SystemsRefreshToken> GetActiveSystemsUserRefreshTokenAsync(string email);
    }
}
