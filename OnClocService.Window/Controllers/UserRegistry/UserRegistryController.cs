using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnClocService.Domain.Requests.UserRegistry;
using OnClocService.Domain.Responses.UserRegistry;
using OnClocService.Infrastructure.Services.UserRegistry;

namespace OnClocService.Window.Controllers.UserRegistry;

public class UserRegistryController(AuthenticationManagerService authenticationService) : BaseController
{
    private readonly AuthenticationManagerService _AuthenticationService = authenticationService;
    private LoginResponse LoginResponse = new();

    [HttpPost]
    [Route("Login")]
    [AllowAnonymous]
    public async Task<IActionResult> LoginAsync(string email, string password)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var loginRequest = new LoginRequest()
        {
            Email = email,
            Password = password,
            RememberMe = false
        };

        LoginResponse = await _AuthenticationService.LoginAsync(loginRequest);
        if (LoginResponse.Success)
        {
            await _AuthenticationService.SaveSecurityCredentials(HttpContext, LoginResponse.SecurityCredentials);
            return Ok(LoginResponse.Message + " - " + LoginResponse.SecurityCredentials.AccessToken);
        }

        return Unauthorized();
    }

    [HttpPost]
    [Route("RefreshToken")]
    public async Task<IActionResult> RefreshTokenAsync(string ticketKey)
    {
        var refreshResponse = await _AuthenticationService.ValidateTicketAsync(ticketKey);
        if (refreshResponse.Success)
        {
            return Ok(ticketKey);
        }

        return Unauthorized();
    }

    [HttpPost]
    [Route("Logout")]
    public async Task<IActionResult> LogoutAsync()
    {
        var securityCredentials = _AuthenticationService.GetSecurityCredentials(HttpContext);
        var ticketKey = securityCredentials.TicketKey;
        if (!string.IsNullOrEmpty(ticketKey))
        {
            await _AuthenticationService.LogoutAsync(ticketKey);
            _AuthenticationService.RemoveSecurityCredentials(HttpContext);
        }
        return Ok();
    }
}
