using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OnClocService.Portal.Pages;

public class AboutModel : PageModel
{
    public IActionResult OnGet()
    {
        return Page();
    }
}
