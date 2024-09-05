#nullable disable

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnClocService.Core.Entities.UserRegistry;

namespace OnClocService.Portal.Areas.UserRegistry.Pages.Manage;

public class ResetAuthenticatorModel(UserManager<SystemsUser> userManager, SignInManager<SystemsUser> signInManager, ILogger<ResetAuthenticatorModel> logger) : PageModel
{
    private readonly UserManager<SystemsUser> _UserManager = userManager;
    private readonly SignInManager<SystemsUser> _SignInManager =signInManager;
    private readonly ILogger<ResetAuthenticatorModel> _AuditLogger = logger;

    [TempData]
    public string StatusMessage { get; set; }

    public async Task<IActionResult> OnGet()
    {
        var user = await _UserManager.GetUserAsync(User);
        if (user == null)
        {
            return NotFound($"Unable to load user with ID '{_UserManager.GetUserId(User)}'.");
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var user = await _UserManager.GetUserAsync(User);
        if (user == null)
        {
            return NotFound($"Unable to load user with ID '{_UserManager.GetUserId(User)}'.");
        }

        await _UserManager.SetTwoFactorEnabledAsync(user, false);
        await _UserManager.ResetAuthenticatorKeyAsync(user);
        var userId = await _UserManager.GetUserIdAsync(user);
        _AuditLogger.LogInformation("User with ID '{UserId}' has reset their authentication app key.", userId);

        await _SignInManager.RefreshSignInAsync(user);
        StatusMessage = "Your authenticator app key has been reset, you will need to configure your authenticator app using the new key.";

        return RedirectToPage("./EnableAuthenticator");
    }
}
