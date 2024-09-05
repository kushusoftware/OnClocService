#nullable disable

using Microsoft.AspNetCore.Http;
using OnClocService.Domain.DataModels.Systems;
using OnClocService.Domain.Interfaces.UserRegistry;
using System.Security.Claims;

namespace OnClocService.Infrastructure.Handlers.UserRegistry;

internal class UserServiceHandler(IHttpContextAccessor httpContextAccessor) : IUserContextService
{
    public CurrentUser GetCurrentUser(ClaimsPrincipal principal)
    {
        var useId = principal.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
        var email = principal.FindFirst(c => c.Type == ClaimTypes.Email)!.Value;
        var roles = principal.Claims.Where(c => c.Type == ClaimTypes.Role)!.Select(c => c.Value);
        return new CurrentUser(useId, email, roles);
    }

    public ClaimsPrincipal GetCurrentPrincipal()
    {
        var principal = (httpContextAccessor?.HttpContext?.User) ?? throw new InvalidOperationException("principal is not present");
        if (principal.Identity == null || !principal.Identity.IsAuthenticated)
        {
            return null;
        }
        return principal;
    }
}
