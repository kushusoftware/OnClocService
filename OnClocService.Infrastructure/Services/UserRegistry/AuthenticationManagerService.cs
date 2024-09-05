using Microsoft.AspNetCore.Http;
using OnClocService.Domain.Interfaces.UserRegistry;
using OnClocService.Domain.Requests.UserRegistry;
using OnClocService.Domain.Responses.UserRegistry;

namespace OnClocService.Infrastructure.Services.UserRegistry;

public class AuthenticationManagerService(IAuthenticationManagerService authenticationManager)
{
    public async Task<LoginResponse> LoginAsync(LoginRequest loginRequest) => await authenticationManager.AuthenticateAsync(loginRequest);
    public async Task<TicketValidationResponse> ValidateTicketAsync(string ticketKey) => await authenticationManager.ValidateAuthenticationTicketAsync(ticketKey);
    public async Task LogoutAsync(string ticketKey) => await authenticationManager.LogoutUserAsync(ticketKey);
    public async Task SaveSecurityCredentials(HttpContext httpContext, SecurityCredentials credentials) => await authenticationManager.SaveSecurityCredentials(httpContext, credentials);
    public SecurityCredentials GetSecurityCredentials(HttpContext httpContext) => authenticationManager.GetSecurityCredentials(httpContext);
    public void RemoveSecurityCredentials(HttpContext httpContext) => authenticationManager.RemoveSecurityCredentials(httpContext);
}