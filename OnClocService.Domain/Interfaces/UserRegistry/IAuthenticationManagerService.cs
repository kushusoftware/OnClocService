using Microsoft.AspNetCore.Http;
using OnClocService.Domain.Requests.UserRegistry;
using OnClocService.Domain.Responses.UserRegistry;

namespace OnClocService.Domain.Interfaces.UserRegistry;

public interface IAuthenticationManagerService
{
    Task<LoginResponse> AuthenticateAsync(LoginRequest loginRequest);
    Task<TicketValidationResponse> ValidateAuthenticationTicketAsync(string ticketKey);
    Task LogoutUserAsync(string ticketKey);
    Task SaveSecurityCredentials(HttpContext httpContext, SecurityCredentials credentials);
    SecurityCredentials GetSecurityCredentials(HttpContext httpContext);
    void RemoveSecurityCredentials(HttpContext httpContext);
}
