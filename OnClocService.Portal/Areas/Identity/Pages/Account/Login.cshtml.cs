#nullable disable

using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnClocService.Domain.Requests.UserRegistry;
using OnClocService.Domain.Responses.UserRegistry;
using OnClocService.Infrastructure.Services.UserRegistry;

namespace OnClocService.Portal.Areas.Identity.Pages.Account;

public class LoginModel(
    AuthenticationManagerService authenticationService, 
    IValidator<LoginRequest> loginValidator, 
    ILogger<LoginModel> logger) : PageModel
{
    private readonly AuthenticationManagerService _AuthenticationService = authenticationService;
    private readonly IValidator<LoginRequest> _LoginValidator = loginValidator;
    private readonly ILogger<LoginModel> _logger = logger;

    [BindProperty]
    public LoginRequest LoginRequest { get; set; }
    public LoginResponse LoginResponse { get; set; }
    public string ReturnUrl { get; set; }

    [TempData]
    public string ErrorMessage { get; set; }

    public async Task OnGetAsync(string returnUrl = null)
    {
        if (!string.IsNullOrEmpty(ErrorMessage))
        {
            ModelState.AddModelError(string.Empty, ErrorMessage);
        }

        returnUrl ??= Url.Content("~/");

        // Clear the existing external cookie to ensure a clean login process
        await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

        ReturnUrl = returnUrl;
    }

    public async Task<IActionResult> OnPostAsync(string returnUrl = null)
    {
        returnUrl ??= Url.Content("~/");

        ValidationResult result = await _LoginValidator.ValidateAsync(LoginRequest);
        if (!result.IsValid)
        {
            result.AddToModelState(this.ModelState);
            return Page();
        }

        if (ModelState.IsValid)
        {
            LoginResponse = await _AuthenticationService.LoginAsync(LoginRequest);
            if (LoginResponse.Success)
            {
                await _AuthenticationService.SaveSecurityCredentials(HttpContext, LoginResponse.SecurityCredentials);
                _logger.LogInformation("User logged in.");
                return LocalRedirect(returnUrl);
            }
            if (LoginResponse.Requires2FA)
            {
                return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, LoginRequest.RememberMe });
            }
            if (LoginResponse.LockedOut)
            {
                _logger.LogWarning("User account locked out.");
                return RedirectToPage("./Lockout");
            }
            else
            {
                ModelState.AddModelError("loginError", LoginResponse.Message);
                return Page();
            }
        }

        // If we got this far, something failed, redisplay form
        return Page();
    }
}
