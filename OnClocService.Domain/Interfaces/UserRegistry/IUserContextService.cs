using OnClocService.Domain.DataModels.Systems;
using System.Security.Claims;

namespace OnClocService.Domain.Interfaces.UserRegistry
{
    public interface IUserContextService
    {
        CurrentUser GetCurrentUser(ClaimsPrincipal principal);
        ClaimsPrincipal GetCurrentPrincipal();
    }
}
