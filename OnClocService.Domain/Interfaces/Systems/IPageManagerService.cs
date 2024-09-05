using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnClocService.Core.Entities.Systems;
using OnClocService.Core.Entities.UserRegistry;
using OnClocService.Domain.DataModels.Systems;

namespace OnClocService.Domain.Interfaces.Systems;

public interface IPageManagerService
{
    // Page Management
    bool IsPageRegistered(string pageId);
    IQueryable<SystemsPage> GetAllPages { get; }
    string GetPageTitle(HttpRequest httpRequest);
    Task<IEnumerable<SystemsPage>> GetAllPagesAsync();
    Task<SystemsPage> GetPageByName(string pageName);
    Task<bool> AddSystemsPageAsync(SystemsPage page);
    SelectList GetOrderedListOfModules(string selectedModuleId);
    PredictedPageIdentifier GenerateNewPageIdentifier(string moduleId);
    PredictedSubModuleIdentifier GenerateNewSubModuleIdentifier(string moduleId);
    Task<IEnumerable<SystemsPage>> GetAllPagesByModuleAreaNameAsync(string moduleAreaName);

    // Module Management
    bool IsModuleRegistered(string moduleId);
    SystemsModule GetModule(string moduleId);
    Task<SystemsModule> GetModuleByName(string moduleName);
    Task<SystemsModule> GetModuleByAreaName(string moduleAreaName);
    IEnumerable<SystemsModule> GetAllModules { get; }
    Task<IEnumerable<SystemsModule>> GetAllModulesAsync();
    Task<SystemsModule> AddSystemsModuleAsync(SystemsModule module);

    // Customizations
    PageNavigation GetCurrentPageCustomization(HttpRequest httpRequest);
    ModulePageLinks GetPageLinksByRequest(HttpRequest httpRequest);
    Task<IList<NavigationMenuChildItem>> GetAllNavigationMenuPageItemsAsync();
    Task<Dictionary<string, NavigationMenuParentItem>> BuildNavigationMenuTreeAsync(IList<NavigationMenuChildItem> sideMenuPages, IList<SystemsRoleClaim> roleClaims);
}
