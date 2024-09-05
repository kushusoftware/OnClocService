using OnClocService.Domain.DataModels.Systems;
using OnClocService.Domain.Interfaces.UserRegistry;
using System.Security.Claims;

namespace OnClocService.Infrastructure.Services.UserRegistry;

public class UserContextService(IUserContextService userContext)
{
    public CurrentUser GetUser(ClaimsPrincipal principal) => userContext.GetCurrentUser(principal);
    public ClaimsPrincipal GetPrincipal() => userContext.GetCurrentPrincipal();
}
