using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace OnClocService.Window.Controllers;

[ApiController]
[Route("kushu/[controller]")]
public class BaseController : ControllerBase
{
    protected string UserId => FindClaim(ClaimTypes.NameIdentifier);
    private string FindClaim(string claimName)
    {
        var claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;
        var claim = claimsIdentity!.FindFirst(claimName);

        if (claim == null)
        {
            return null!;
        }
        return claim.Value;
    }
}
