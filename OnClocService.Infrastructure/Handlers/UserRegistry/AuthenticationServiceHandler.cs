#nullable disable

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using OnClocService.Core.Entities.UserRegistry;
using OnClocService.Domain.Interfaces.UserRegistry;
using OnClocService.Domain.Middleware;
using OnClocService.Domain.Requests.UserRegistry;
using OnClocService.Domain.Responses.UserRegistry;
using OnClocService.Infrastructure.Services.UserRegistry;

namespace OnClocService.Infrastructure.Handlers.UserRegistry;

internal class AuthenticationServiceHandler(
    UserManager<SystemsUser> userManager, SignInManager<SystemsUser> signInManager,
    TokenManagerService tokenManager, UserContextService userContext,
    TicketManagerService ticketManager) : IAuthenticationManagerService
{
    private readonly SignInManager<SystemsUser> _SignInManager = signInManager;
    private readonly UserManager<SystemsUser> _UserManager = userManager;
    private readonly TokenManagerService _TokenManager = tokenManager;
    private readonly TicketManagerService _TicketManager = ticketManager;
    private readonly UserContextService _UserContext = userContext;
    private const string TICKET_KEY = nameof(TICKET_KEY);
    private const string ACCESS_KEY = nameof(ACCESS_KEY);
    private const string REFRESH_KEY = nameof(REFRESH_KEY);
    private const string REFRESH_EXP = nameof(REFRESH_EXP);

    public async Task<LoginResponse> AuthenticateAsync(LoginRequest loginRequest)
    {
        var loginResponse = new LoginResponse();
        // SignIn the User
        var result = await _SignInManager.PasswordSignInAsync(loginRequest.Email, loginRequest.Password, loginRequest.RememberMe, lockoutOnFailure: true);
        if (!result.Succeeded)
        {
            loginResponse.Message = "invalid user credentials";
            return loginResponse;
        }
        // Get User Principal
        var principal = _UserContext.GetPrincipal();
        if (principal is null)
        {
            loginResponse.Message = "incomplete signin process";
            return loginResponse;
        }
        // Check Saved Refresh TicketKey
        var refreshToken = await _TokenManager.RetrieveActiveRefreshTokenAsync(loginRequest.Email);
        if (refreshToken != null && !string.IsNullOrEmpty(refreshToken.Token))
        {
            await _TokenManager.RevokeRefreshTokenAsync(refreshToken);
        }
        // Get Authentication Ticket
        var ticket = await _TokenManager.GetAuthenticationTicketAsync(principal);
        if (ticket is null)
        {
            loginResponse.Message = $"no user enroled with email; {loginRequest.Email}";
            return loginResponse;
        }
        // create new Refresh TicketKey
        var newAccessToken = ticket.Properties.GetTokenValue(ACCESS_KEY);
        var newRefreshToken = ticket.Properties.GetTokenValue(REFRESH_KEY);
        var refreshTokenExp = ticket.Properties.GetParameter<DateTimeOffset>(REFRESH_EXP);
        refreshToken = new()
        {
            UserName = loginRequest.Email,
            Token = newRefreshToken,
            Expiry = refreshTokenExp
        };
        // Save Refresh TicketKey
        await _TokenManager.SaveRefreshTokenAsync(refreshToken);
        // Save Authentication Ticket
        var ticketKey = await _TicketManager.StoreAsync(ticket);
        // Get User Details
        var user = await _UserManager.GetUserAsync(principal);
        if (user is not null)
        {
            var securityCredentials = new SecurityCredentials()
            {
                TicketKey = ticketKey,
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken,
            };
            // Create LoginAsync Response
            loginResponse.Success = true;
            loginResponse.SecurityCredentials = securityCredentials;
            loginResponse.LockedOut = user.LockoutEnabled;
            loginResponse.Requires2FA = user.TwoFactorEnabled;
            loginResponse.Message = $"{loginRequest.Email} successfully logged in";
        }
        // Return LoginAsync Response
        return loginResponse;
    }

    public async Task<TicketValidationResponse> ValidateAuthenticationTicketAsync(string ticketKey)
    {
        // Initialize Response
        var ticketValidationResponse = new TicketValidationResponse
        {
            Success = false
        };
        // Retrive Authentication Ticket
        var ticket = await _TicketManager.RetrieveAsync(ticketKey);
        if (ticket is null)
        {
            ticketValidationResponse.ErrorCode = "V0101";
            ticketValidationResponse.Error = "invalid authentication ticket";
            return ticketValidationResponse;
        }
        // Check Token Expiry
        var accessExpiry = ticket.Properties.ExpiresUtc!.Value;
        var refreshExpiry = ticket.Properties.GetParameter<DateTimeOffset>(REFRESH_EXP);
        // Get Token String
        var accessToken = ticket.Properties.GetTokenValue(ACCESS_KEY);
        var refreshToken = ticket.Properties.GetTokenValue(REFRESH_KEY);
        // Evaluate Validity
        bool accessIsValid = accessExpiry > DateTimeOffset.UtcNow;
        bool refreshIsValid = refreshExpiry > DateTimeOffset.UtcNow;
        if (accessIsValid && refreshIsValid && accessToken is not null && refreshToken is not null)
        {
            ticketValidationResponse.Success = true;
            ticketValidationResponse.AuthenticationTicket = ticket;
            return ticketValidationResponse;
        }
        // Missing Access Token
        if (accessToken is null)
        {
            ticketValidationResponse.ErrorCode = "V0101";
            ticketValidationResponse.Error = "missing access token";
            return ticketValidationResponse;
        }
        // Missing Refresh Token
        if (refreshToken is null)
        {
            ticketValidationResponse.ErrorCode = "V0101";
            ticketValidationResponse.Error = "missing refresh token";
            return ticketValidationResponse;
        }
        // Get User Principal from Expired Token
        var principal = await _TokenManager.GetPrincipalFromTokenAsync(accessToken);
        if (principal is null)
        {
            ticketValidationResponse.ErrorCode = "V0101";
            ticketValidationResponse.Error = "invalid user for token";
            return ticketValidationResponse;
        }
        // Get User Details
        var user = await _UserManager.GetUserAsync(principal);
        if (user is null)
        {
            ticketValidationResponse.ErrorCode = "V0101";
            ticketValidationResponse.Error = "invalid user in token";
            return ticketValidationResponse;
        }
        // Get Active Refresh Token
        var activeRefereshToken = await _TokenManager.RetrieveActiveRefreshTokenAsync(user.Email!);
        if (activeRefereshToken is null)
        {
            ticketValidationResponse.ErrorCode = "V0101";
            ticketValidationResponse.Error = "invalid refresh peer";
            return ticketValidationResponse;
        }
        // Validate Refresh Token
        if (refreshToken != activeRefereshToken.Token)
        {
            ticketValidationResponse.ErrorCode = "V0101";
            ticketValidationResponse.Error = "invalid refresh validation";
            return ticketValidationResponse;
        }
        // Update Authentication Ticket
        if (!accessIsValid && refreshIsValid)
        {
            ticket = await _TokenManager.RefreshAuthenticationTicketAsync(ticket);
            await _TicketManager.RenewAsync(ticketKey, ticket);
            ticketValidationResponse.Success = true;
            ticketValidationResponse.AuthenticationTicket = ticket;
            return ticketValidationResponse;
        }
        // Else Revoke Refresh Token
        await _TokenManager.RevokeRefreshTokenAsync(activeRefereshToken);
        return ticketValidationResponse;
    }

    public async Task LogoutUserAsync(string ticketKey)
    {
        var principal = _UserContext.GetPrincipal();
        if (principal == null) { return; }
        var user = await _UserManager.GetUserAsync(principal);
        if (user == null) { return; }
        var refreshToken = await _TokenManager.RetrieveActiveRefreshTokenAsync(user.Email!);
        if (refreshToken is not null)
        {
            await _TokenManager.RevokeRefreshTokenAsync(refreshToken);
        }
        await _TicketManager.RemoveAsync(ticketKey);
        await _SignInManager.SignOutAsync();
    }

    public async Task SaveSecurityCredentials(HttpContext httpContext, SecurityCredentials credentials)
    {
        // Save Ticket Key
        await httpContext.Session.LoadAsync();
        httpContext.Session.SetString(TICKET_KEY, credentials.TicketKey);
        await httpContext.Session.CommitAsync();
        // Save Security Credentials
        httpContext.Items[SecurityCredentialsMiddleware.AccessToken] = credentials.AccessToken;
        httpContext.Items[SecurityCredentialsMiddleware.RefreshToken] = credentials.RefreshToken;
    }

    public SecurityCredentials GetSecurityCredentials(HttpContext httpContext)
    {
        // Fetch Ticket Key
        httpContext.Session.TryGetValue(TICKET_KEY, out var ticketKeyValue);
        // Fetch Security Credentials
        httpContext.Items.TryGetValue(SecurityCredentialsMiddleware.AccessToken, out var accessTokenValue);
        httpContext.Items.TryGetValue(SecurityCredentialsMiddleware.RefreshToken, out var refreshTokenValue);
        return new SecurityCredentials()
        {
            TicketKey = ticketKeyValue.ToString() ?? string.Empty,
            AccessToken = accessTokenValue.ToString() ?? string.Empty,
            RefreshToken = refreshTokenValue.ToString() ?? string.Empty
        };
    }

    public void RemoveSecurityCredentials(HttpContext httpContext) 
    { 
        // Remove Ticket Key
        httpContext.Session.Clear();
        // Remove Security Credentials
        httpContext.Items.Remove(SecurityCredentialsMiddleware.AccessToken);
        httpContext.Items.Remove(SecurityCredentialsMiddleware.RefreshToken);
    }
}

