#nullable disable

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnClocService.Core.Entities.UserRegistry;

namespace OnClocService.Portal.Areas.UserRegistry.Pages.Manage;

public class TwoFactorAuthenticationModel(UserManager<SystemsUser> userManager, SignInManager<SystemsUser> signInManager, ILogger<TwoFactorAuthenticationModel> logger) : PageModel
{
    private readonly UserManager<SystemsUser> _UserManager = userManager;
    private readonly SignInManager<SystemsUser> _SignInManager = signInManager;
    private readonly ILogger<TwoFactorAuthenticationModel> _AuditLogger = logger;

    [BindProperty]
    public bool Is2faEnabled { get; set; }
    public bool HasAuthenticator { get; set; }
    public int RecoveryCodesLeft { get; set; }
    public bool IsMachineRemembered { get; set; }

    [TempData]
    public string StatusMessage { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        var user = await _UserManager.GetUserAsync(User);
        if (user == null)
        {
            return NotFound($"Unable to load user with ID '{_UserManager.GetUserId(User)}'.");
        }

        HasAuthenticator = await _UserManager.GetAuthenticatorKeyAsync(user) != null;
        Is2faEnabled = await _UserManager.GetTwoFactorEnabledAsync(user);
        IsMachineRemembered = await _SignInManager.IsTwoFactorClientRememberedAsync(user);
        RecoveryCodesLeft = await _UserManager.CountRecoveryCodesAsync(user);

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var user = await _UserManager.GetUserAsync(User);
        if (user == null)
        {
            return NotFound($"Unable to load user with ID '{_UserManager.GetUserId(User)}'.");
        }

        await _SignInManager.ForgetTwoFactorClientAsync();
        StatusMessage = "The current browser has been forgotten. When you login again from this browser you will be prompted for your 2fa code.";
        return RedirectToPage();
    }
}
