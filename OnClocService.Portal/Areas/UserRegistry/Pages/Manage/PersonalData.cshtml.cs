using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnClocService.Core.Entities.UserRegistry;

namespace OnClocService.Portal.Areas.UserRegistry.Pages.Manage;

public class PersonalDataModel(UserManager<SystemsUser> userManager, ILogger<PersonalDataModel> logger) : PageModel
{
    private readonly UserManager<SystemsUser> _UserManager = userManager;
    private readonly ILogger<PersonalDataModel> _AuditLogger = logger;

    public async Task<IActionResult> OnGet()
    {
        var user = await _UserManager.GetUserAsync(User);
        if (user == null)
        {
            return NotFound($"Unable to load user with ID '{_UserManager.GetUserId(User)}'.");
        }

        return Page();
    }
}
