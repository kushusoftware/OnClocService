#nullable disable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnClocService.Infrastructure.Services.UserRegistry;

namespace OnClocService.Portal.Areas.Identity.Pages.Account;

public class LogoutModel(
    AuthenticationManagerService authenticationManager, 
    ILogger<LogoutModel> logger) : PageModel
{
    private readonly AuthenticationManagerService _AuthenticationManager = authenticationManager;
    private readonly ILogger<LogoutModel> _logger = logger;

    public async Task<IActionResult> OnPost(string returnUrl = null)
    {
        var securityCredentials = _AuthenticationManager.GetSecurityCredentials(HttpContext);
        var ticketKey = securityCredentials.TicketKey;
        if (!string.IsNullOrEmpty(ticketKey))
        {
            await _AuthenticationManager.LogoutAsync(ticketKey);
            _AuthenticationManager.RemoveSecurityCredentials(HttpContext);
        }
        _logger.LogInformation("User logged out.");
        if (returnUrl != null)
        {
            return LocalRedirect(returnUrl);
        }
        else
        {
            // This needs to be a redirect so that the browser performs a new
            // request and the identity for the user gets updated.
            return RedirectToPage();
        }
    }
}
