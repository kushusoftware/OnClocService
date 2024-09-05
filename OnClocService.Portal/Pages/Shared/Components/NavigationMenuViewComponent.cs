using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnClocService.Core.Entities.UserRegistry;
using OnClocService.Domain.Interfaces.Systems;
using OnClocService.Infrastructure.DataStorage;
using System.Security.Claims;

namespace OnClocService.Portal.Pages.Shared.Components
{
    [ViewComponent(Name = "NavigationMenu")]
    public class NavigationMenuViewComponent(
        OnClocDataStorageContext appDataContext, 
        UserManager<SystemsUser> userManager, 
        RoleManager<SystemsRole> roleManager, 
        IPageManagerService pageManager) : ViewComponent
    {
        private readonly OnClocDataStorageContext _DataContext = appDataContext;
        private readonly UserManager<SystemsUser> _UserManager = userManager;
        private readonly RoleManager<SystemsRole> _RoleManager = roleManager;
        private readonly IPageManagerService _PageManager = pageManager;

        public async Task<IViewComponentResult> InvokeAsync(ClaimsPrincipal userPrinciple)
        {
            IList<SystemsRoleClaim> allRoleClaims = [];
            {
                var currentUser = await _UserManager.GetUserAsync(userPrinciple);
                if (currentUser != null)
                {
                    var currentRoleNames = await _UserManager.GetRolesAsync(currentUser);
                    foreach (var roleName in currentRoleNames)
                    {
                        var role = _RoleManager.Roles.First(r => r.Name == roleName);
                        var roleClaims = await _RoleManager.GetClaimsAsync(role);
                        var rawRoleClaims = _DataContext.RoleClaims.Where(rc => rc.RoleId == role.Id).ToList();
                        foreach (var roleClaim in roleClaims)
                        {
                            allRoleClaims.Add(new SystemsRoleClaim
                            {
                                ClaimType = roleClaim.Type,
                                ClaimValue = roleClaim.Value,
                                RoleId = role.Id
                            });
                        }
                    }
                }
            }
            var navMenuItems = await _PageManager.GetAllNavigationMenuPageItemsAsync();
            return View("NavigationMenu", await _PageManager.BuildNavigationMenuTreeAsync(navMenuItems, allRoleClaims));
        }
    }
}
