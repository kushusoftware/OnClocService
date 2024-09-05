
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnClocService.Core.Constants;
using OnClocService.Core.Entities.Systems;
using OnClocService.Core.Entities.UserRegistry;
using OnClocService.Domain.DataModels.Systems;
using OnClocService.Domain.Helpers;
using OnClocService.Domain.Interfaces.Systems;
using OnClocService.Infrastructure.DataStorage;

namespace OnClocService.Infrastructure.Handlers.Systems;

internal class PageServiceHandler(OnClocDataStorageContext storageContext) : IPageManagerService
{
    private readonly OnClocDataStorageContext _StorageContext = storageContext;
    private readonly string _DefaultModuleName = "dashboard";
    private readonly string _ModuleImageFolder = "/img/layout/module/";
    private readonly string _ModuleThemePrefix = "theme-";

    public SelectList GetOrderedListOfModules(string selectedModuleId)
    {
        List<SelectListItem> modulesList = [];
        // Fetch All BIS Modules and Sub Modules
        IEnumerable<SystemsModule> allModules = GetAllModules;
        foreach (SystemsModule module in allModules)
        {
            // Add Module to List
            string moduleName = module.Name;
            string moduleCode = module.SystemsModuleID;
            bool isSelected = moduleCode.Equals(selectedModuleId);
            if (module.ParentModuleId == null)
            {
                modulesList.Add(new SelectListItem
                {
                    Text = moduleName,
                    Value = moduleCode,
                    Selected = isSelected
                });
                // Add Sub-Module to List
                List<SystemsModule> subModules = allModules.Where(pm => pm.ParentModuleId == module.SystemsModuleID).ToList();
                foreach (var subModule in subModules)
                {
                    string subModuleName = moduleName + ": " + subModule.Name;
                    string subModuleCode = subModule.SystemsModuleID;
                    isSelected = subModuleCode.Equals(selectedModuleId);
                    modulesList.Add(new SelectListItem
                    {
                        Text = subModuleName,
                        Value = subModuleCode,
                        Selected = isSelected
                    });
                }
            }
        }
        SelectList selectItems = new(modulesList, "Value", "Text");
        return selectItems;
    }


    /// <summary>
    /// generates page identifiers
    /// </summary>
    /// <param name="moduleId">page module or sub-module identifier</param>
    /// <returns>predicted next page identifier</returns>
    public PredictedPageIdentifier GenerateNewPageIdentifier(string moduleId)
    {
        List<SystemsPage> modulePages = [.. _StorageContext.SystemsPages.AsNoTracking()
                .Where(p => p.SystemsModuleId == moduleId).OrderByDescending(p => p.Index)];
        int lastPageIndex = 0;
        if (modulePages.Count > 0)
        {
            lastPageIndex = modulePages[0].Index;
        }
        else
        {
            string moduleTag = moduleId[(moduleId.IndexOf('M') + 1)..];
            int moduleIndex = int.Parse(moduleTag);
            moduleIndex *= 100;
            lastPageIndex = moduleIndex;
        }
        // Predict Next Page Index
        int predictedNextPageIndex = lastPageIndex + 1;
        // Predict Next Page ID
        string predictedNextPageId = "P" + predictedNextPageIndex.ToString("000000");
        PredictedPageIdentifier predictedPageIdentifier = new()
        {
            Index = predictedNextPageIndex,
            Id = predictedNextPageId
        };
        return predictedPageIdentifier;
    }

    /// <summary>
    /// generates sub-module identifers
    /// </summary>
    /// <param name="moduleId">module or sub-module identifier</param>
    /// <returns>predicted next sub-module identifier</returns>
    public PredictedSubModuleIdentifier GenerateNewSubModuleIdentifier(string moduleId)
    {
        List<SystemsModule> subModules = [.. _StorageContext.SystemsModules.AsNoTracking()
                .Where(m => m.ParentModuleId == moduleId).OrderByDescending(m => m.Index)];
        int lastSubModuleIndex = 0;
        if (subModules.Count > 0)
        {
            lastSubModuleIndex = subModules[0].Index;
        }
        else
        {
            string moduleTag = moduleId[(moduleId.IndexOf('M') + 1)..];
            lastSubModuleIndex = int.Parse(moduleTag);
        }
        // Predict Next Sub Module Index
        int predictedNextModuleIndex = lastSubModuleIndex + 1;
        // Predict Next Sub Module ID
        string predictedNextModuleId = "M" + predictedNextModuleIndex.ToString("0000");
        PredictedSubModuleIdentifier predictedSubModuleIdentifier = new()
        {
            Index = predictedNextModuleIndex,
            Id = predictedNextModuleId
        };
        return predictedSubModuleIdentifier;
    }

    /// <summary>
    /// confirm page is in registry
    /// </summary>
    /// <param name="pageId">page id</param>
    /// <returns>true of false</returns>
    public bool IsPageRegistered(string pageId) { return _StorageContext.SystemsPages.Any(p => p.SystemsPageID == pageId); }

    /// <summary>
    /// get all registered pages ordered by index
    /// </summary>
    public IQueryable<SystemsPage> GetAllPages
    {
        get { return _StorageContext.SystemsPages.OrderBy(p => p.Index); }
    }

    /// <summary>
    /// get all registered pages async ordered by index
    /// </summary>
    /// <returns>inenumerable list of systems pages</returns>
    public async Task<IEnumerable<SystemsPage>> GetAllPagesAsync()
    {
        return await _StorageContext.SystemsPages.OrderBy(p => p.Index).ToListAsync();
    }

    public async Task<IEnumerable<SystemsPage>> GetAllPagesByModuleAreaNameAsync(string moduleAreaName)
    {
        SystemsModule module = await GetModuleByAreaName(moduleAreaName);
        IEnumerable<SystemsPage> modulePages = [.. new List<SystemsPage>()];
        if (module.SystemsPages != null) { modulePages = module.SystemsPages; }
        return modulePages;
    }

    /// <summary>
    /// add a new page to the page registry
    /// </summary>
    /// <param name="page"></param>
    /// <returns>returns the result systems page</returns>
    /// <exception cref="Exception"></exception>
    public async Task<bool> AddSystemsPageAsync(SystemsPage page)
    {
        if (IsPageRegistered(page.SystemsPageID))
        {
            throw new Exception("failed to add page to registry", new Exception("failed to add page to registry becasue systems-page is already registered"));
        }
        await _StorageContext.SystemsPages.AddAsync(page);
        return _StorageContext.SaveChanges() == 1;
    }

    /// <summary>
    /// confirm module is in registry
    /// </summary>
    /// <param name="moduleId">module id</param>
    /// <returns>true or false</returns>
    public bool IsModuleRegistered(string moduleId) { return _StorageContext.SystemsModules.Any(m => m.SystemsModuleID == moduleId); }

    /// <summary>
    /// get registered module specified
    /// </summary>
    /// <param name="moduleId">module id</param>
    /// <returns>systems module</returns>
    public SystemsModule GetModule(string moduleId)
    {
        return _StorageContext.SystemsModules.AsNoTracking().First(m => m.SystemsModuleID.Equals(moduleId));
    }

    public async Task<SystemsModule> GetModuleByAreaName(string moduleAreaName)
    {
        return await _StorageContext.SystemsModules.FirstAsync(m => m.AspArea == moduleAreaName);
    }

    public async Task<SystemsModule> GetModuleByName(string moduleName)
    {
        return await _StorageContext.SystemsModules.FirstAsync(x => x.Name == moduleName);
    }

    /// <summary>
    /// get all registered modules by index
    /// </summary>
    public IEnumerable<SystemsModule> GetAllModules
    {
        get { return [.. _StorageContext.SystemsModules.OrderBy(m => m.Index)]; }
    }

    /// <summary>
    /// get all registered modules async ordered by index
    /// </summary>
    /// <returns>inumerable list of systems modules</returns>
    public async Task<IEnumerable<SystemsModule>> GetAllModulesAsync()
    {
        return await _StorageContext.SystemsModules.OrderBy(m => m.Index).ToListAsync();
    }

    public async Task<SystemsModule> AddSystemsModuleAsync(SystemsModule module)
    {
        if (IsModuleRegistered(module.SystemsModuleID))
        {
            throw new Exception("failed to add module to registry", new Exception("failed to add module to registry becasue systems-module is already registered"));
        }
        else
        {
            var result = await _StorageContext.SystemsModules.AddAsync(module);
            var saved = await _StorageContext.SaveChangesAsync();
            if (saved > 0) { module = result.Entity; }
        }
        return module;
    }

    /// <summary>
    /// get module default registered page
    /// </summary>
    /// <param name="moduleId">module id</param>
    /// <returns>systems page</returns>
    private SystemsPage? GetDefaultModulePage(string moduleId)
    {
        return _StorageContext.SystemsPages.SingleOrDefault(p => p.IsDefaultPage == true && p.SystemsModuleId == moduleId);
    }

    /// <summary>
    /// build the navigation menu tree
    /// </summary>
    /// <param name="sideMenuPages">menu pages</param>
    /// <returns>dictionary of navigation menu items</returns>
    public async Task<Dictionary<string, NavigationMenuParentItem>> BuildNavigationMenuTreeAsync(IList<NavigationMenuChildItem> sideMenuPages, IList<SystemsRoleClaim> roleClaims)
    {
        // Fetch All BIS Modules and Sub Modules
        var allSystemsModules = await GetAllModulesAsync();
        List<SystemsModule> allowedMenuModules = [];
        if (roleClaims.Count > 0)
        {
            foreach (var roleClaim in roleClaims)
            {
                var permissionSignature = SystemsPermissionHelper.GetPermissionSignatureFromRoleClaim(roleClaim);
                var moduleAspArea = permissionSignature.Module;
                if (moduleAspArea == SysModule.Dashboard) { moduleAspArea = null; }
                var allowedSubMenuModules = allSystemsModules.Where(m => m.AspArea == moduleAspArea && m.ShowInMenu == true);
                if (allowedSubMenuModules != null) { allowedMenuModules.AddRange(allowedSubMenuModules); }
            }
        }

        // Create Navigation Menu Map
        Dictionary<string, NavigationMenuParentItem> navigationMenuMap = [];

        // Add Parent Navigation Items to the Dictionary
        foreach (var menuItem in allowedMenuModules)
        {
            string moduleId = menuItem.SystemsModuleID;
            string parentModuleId = "";
            if (menuItem.ParentModuleId != null) parentModuleId = menuItem.ParentModuleId;

            ModuleTheme moduleSettings = GetModuleCustomization(moduleId);
            NavigationMenuParentItem bisModule = new()
            {
                MenuItemID = moduleId,
                MenuParentID = parentModuleId,
                MenuItemIndex = menuItem.Index,
                ModuleName = menuItem.Name,
                ModuleTitle = menuItem.Title,
                ModuleIconClass = menuItem.IconClass,
                IsDefaultModule = menuItem.IsDefaultModule,
                IsActiveMenuItem = menuItem.EnableMenuItem,
                ModuleShortName = moduleSettings.ModuleShortName,
                ModuleImageUrl = moduleSettings.ModuleImgUrl,
                ModuleMainClass = moduleSettings.ModuleMainClass,
                IsParentMenuItem = moduleSettings.IsParentMenuItem,
                IsVisibleMenuItem = moduleSettings.IsVisibleMenuItem
            };
            // Add Child Navigation Items to Dictionary Item
            List<NavigationMenuChildItem> bisModulePages = [];
            bisModulePages = sideMenuPages.Where(p => p.MenuParentItemID == moduleId).ToList();
            if (bisModulePages.Count != 0)
            {
                foreach (NavigationMenuChildItem bisMenuPage in bisModulePages)
                {
                    bisModule.ChildMenuItems.Add(bisMenuPage);
                }
            }
            navigationMenuMap.Add(moduleId, bisModule);
        }
        // Navigation Map Dictionary
        return navigationMenuMap;
    }

    /// <summary>
    /// get all navigation menu items asyncronously
    /// </summary>
    /// <returns>list of navigation menu child items</returns>
    public async Task<IList<NavigationMenuChildItem>> GetAllNavigationMenuPageItemsAsync()
    {
        // Fetch All Systems Pages
        var allPages = await GetAllPagesAsync();
        List<SystemsPage> allowedPages = allPages.Where(p => p.ShowInMenu == true).ToList();
        List<NavigationMenuChildItem> navigationMenuPageItems = [];

        // Add Child Navigation Menu Items to List
        foreach (var allowedPage in allowedPages)
        {
            string moduleId = allowedPage.SystemsModuleId;
            SystemsModule bisModule = GetModule(moduleId);
            string? moduleAspArea;
            if (bisModule.IsDefaultModule)
            {
                moduleAspArea = "";
            }
            else
            {
                moduleAspArea = bisModule.AspArea;
            }

            NavigationMenuChildItem menuPage = new()
            {
                MenuItemID = allowedPage.SystemsPageID,
                MenuParentItemID = allowedPage.SystemsModuleId,
                MenuItemIndex = allowedPage.Index,
                MenuItemName = allowedPage.Name,
                MenuItemTitle = allowedPage.Title,
                MenuItemAspArea = moduleAspArea,
                MenuItemAspPage = allowedPage.AspParentFolder + "/" + allowedPage.AspPage,
                MenuItemIconClass = allowedPage.IconClass,
                IsActiveMenuItem = allowedPage.EnableMenuItem,
                IsDefaultModuleItem = allowedPage.IsDefaultPage,
                IsVisibleMenuItem = allowedPage.ShowInMenu
            };
            navigationMenuPageItems.Add(menuPage);
        }
        return navigationMenuPageItems;
    }

    public string GetPageTitle(HttpRequest httpRequest)
    {
        var routeValues = httpRequest.RouteValues;

        var aspPage = string.Empty;
        if (routeValues["page"] != null)
        {
            aspPage = routeValues["page"]!.ToString();
            if (aspPage != null && aspPage.Contains('/'))
            {
                aspPage = aspPage[(aspPage.LastIndexOf('/') + 1)..];
            }
        }
        var aspArea = string.Empty;
        if (routeValues["area"] != null)
        {
            aspArea = routeValues["area"]!.ToString();
        }

        var currentPage = GetPageByArea(aspArea, aspPage);
        return currentPage.Title;
    }

    public PageNavigation GetCurrentPageCustomization(HttpRequest httpRequest)
    {
        string baseUrl = httpRequest.Scheme + "://" + httpRequest.Host.Value;
        var httpRequestFeature = httpRequest.HttpContext.Features.Get<IHttpRequestFeature>();
        var uri = "";
        if (httpRequestFeature != null) uri = httpRequestFeature.RawTarget;

        var routeValues = httpRequest.RouteValues;

        var aspPage = string.Empty;
        if (routeValues["page"] != null)
        {
            aspPage = routeValues["page"]!.ToString();
            if (aspPage != null && aspPage.Contains('/'))
            {
                aspPage = aspPage[(aspPage.LastIndexOf('/') + 1)..];
            }
        }
        var aspArea = string.Empty;
        if (routeValues["area"] != null)
        {
            aspArea = routeValues["area"]!.ToString();
        }

        var currentPage = GetPageByArea(aspArea, aspPage);
        var customization = new PageNavigation();
        if (currentPage != null)
        {
            customization = GetPageCustomization(currentPage, baseUrl, uri);
        }
        return customization;
    }

    public PageNavigation GetPageCustomization(SystemsPage currentPage, string baseUrl, string uri)
    {
        var routeParts = new Uri(baseUrl + uri);
        List<string> breadcrumbParts = [];
        foreach (var segment in routeParts.Segments)
        {
            int lastSegmentSlash = segment.LastIndexOf('/');
            string segmentNoSlash = lastSegmentSlash > -1 ? segment[..lastSegmentSlash] : segment;
            if (int.TryParse(segmentNoSlash, out int _)) { continue; }
            segmentNoSlash = segmentNoSlash.ToLower();
            if (segmentNoSlash == "")
            {
                segmentNoSlash = "Index";
            }
            breadcrumbParts.Add(segmentNoSlash);
        }
        // Check Current Active Page
        int topSegmentIndex = breadcrumbParts.Count - 1;
        for (int i = 0; i <= topSegmentIndex; i++)
        {
            var segment = breadcrumbParts[topSegmentIndex];
            if (string.Equals(segment, currentPage.AspPage, StringComparison.OrdinalIgnoreCase))
            {
                break;
            }
            topSegmentIndex--;
        }
        // Get Current Module ID
        string currentModuleId = currentPage.SystemsModuleId;
        var currentModule = GetModule(currentModuleId);
        // Check Current Module is a Parent or Child Module
        bool currentModuleIsParent = currentModule.ParentModuleId == null;
        // Get Current Module Parent
        string currentModuleParentId = "";
        SystemsModule currentModuleParent = new();
        if (currentModule.ParentModuleId != null)
        {
            currentModuleParentId = currentModule.ParentModuleId;
            currentModuleParent = GetModule(currentModuleParentId);
        }
        // Create a Breadcrumb List
        string moduleImgUrl, moduleShortName, moduleMainClass;
        // Get Core Page Theme
        if (currentModuleIsParent)
        {
            moduleShortName = GetModuleShortName(currentModule);
            moduleImgUrl = _ModuleImageFolder + currentModule.ModuleImageFile;
        }
        else
        {
            moduleShortName = GetModuleShortName(currentModuleParent);
            moduleImgUrl = _ModuleImageFolder + currentModuleParent.ModuleImageFile;
        }
        moduleMainClass = _ModuleThemePrefix + moduleShortName;
        // Create Page Theme Customization
        var customPageNavigation = new PageNavigation()
        {
            ModuleShortName = moduleShortName,
            ModuleMainClass = moduleMainClass,
            ModuleImgUrl = moduleImgUrl
        };
        // Check Default Module Page
        var defaultModulePage = GetDefaultModulePage(currentModuleId);
        bool currentPageIsDefaultPage = defaultModulePage == currentPage;
        var currentModuleDefaultPage = GetDefaultModulePage(currentModuleId);
        var currentModuleParentDefaultPage = GetDefaultModulePage(currentModuleParentId);

        // Add to Breadcrumb List
        List<BreadcrumbItem> breadLoaf = [];
        if (currentModuleIsParent && currentPageIsDefaultPage)
        {
            // Do Nothing More...
        }
        else if (currentModuleIsParent && !currentPageIsDefaultPage)
        {
            if (currentModuleDefaultPage != null)
            {
                breadLoaf.Add(new BreadcrumbItem
                {
                    AspArea = currentModule.AspArea,
                    AspPage = currentModuleDefaultPage.AspPage,
                    PageIconClass = currentModuleDefaultPage.IconClass,
                    PageTitle = currentModuleDefaultPage.Title,
                    PageDescription = currentModuleDefaultPage.Description,
                    IsActivePage = false
                });
            }
        }
        else if (!currentModuleIsParent && currentPageIsDefaultPage)
        {
            if (currentModuleParentDefaultPage != null)
            {
                breadLoaf.Add(new BreadcrumbItem
                {
                    AspArea = currentModuleParent.AspArea,
                    AspPage = currentModuleParentDefaultPage.AspPage,
                    PageIconClass = currentModuleParentDefaultPage.IconClass,
                    PageTitle = currentModuleParentDefaultPage.Title,
                    PageDescription = currentModuleParentDefaultPage.Description,
                    IsActivePage = false
                });
            }
        }
        else if (!currentModuleIsParent && !currentPageIsDefaultPage)
        {
            if (currentModuleParentDefaultPage != null)
            {
                breadLoaf.Add(new BreadcrumbItem
                {
                    AspArea = currentModuleParent.AspArea,
                    AspPage = currentModuleParentDefaultPage.AspPage,
                    PageIconClass = currentModuleParentDefaultPage.IconClass,
                    PageTitle = currentModuleParentDefaultPage.Title,
                    PageDescription = currentModuleParentDefaultPage.Description,
                    IsActivePage = false
                });
            }

            if (currentModuleDefaultPage != null)
            {
                breadLoaf.Add(new BreadcrumbItem
                {
                    AspArea = currentModule.AspArea,
                    AspPage = currentModuleDefaultPage.AspPage,
                    PageIconClass = currentModuleDefaultPage.IconClass,
                    PageTitle = currentModuleDefaultPage.Title,
                    PageDescription = currentModuleDefaultPage.Description,
                    IsActivePage = false
                });
            }
        }
        breadLoaf.Add(new BreadcrumbItem
        {
            AspArea = currentModule.AspArea,
            AspPage = currentPage.AspPage,
            PageIconClass = currentPage.IconClass,
            PageTitle = currentPage.Title,
            PageDescription = currentPage.Description,
            IsActivePage = true
        });

        // Update the Page Theme
        foreach (BreadcrumbItem bread in breadLoaf)
        {
            customPageNavigation.BreadcrumbItems.Add(bread);
        }
        return customPageNavigation;
    }

    public async Task<SystemsPage> GetPageByName(string pageName)
    {
        return await _StorageContext.SystemsPages.FirstAsync(x => x.Name == pageName);
    }

    public SystemsPage GetPageByArea(string? aspArea, string? aspPage)
    {
        bool isRegistered = false;
        List<SystemsModule> parentModules =
        [
            .. _StorageContext.SystemsModules.Where(m => m.AspArea == aspArea || m.IsDefaultModule == true).Include(m => m.SystemsPages)
        ];

        SystemsPage systemsPage = new();

        foreach (SystemsModule parentModule in parentModules)
        {
            if (parentModule.SystemsPages != null)
            {
                string? parentAspArea = parentModule.AspArea ?? "";
                foreach (SystemsPage page in parentModule.SystemsPages)
                {
                    if (string.Equals(aspPage, page.AspPage, StringComparison.OrdinalIgnoreCase)
                        && string.Equals(aspArea, parentAspArea, StringComparison.OrdinalIgnoreCase))
                    {
                        systemsPage = page;
                        isRegistered = true;
                        break;
                    }
                }
            }
            if (isRegistered) { break; }
            else
            {
                List<SystemsModule> childModules =
                [
                    .. _StorageContext.SystemsModules.Where(m => m.ParentModuleId == parentModule.SystemsModuleID).Include(m => m.SystemsPages),
                    ];
                foreach (SystemsModule childModule in childModules)
                {
                    if (childModule.SystemsPages != null)
                    {
                        foreach (SystemsPage childPage in childModule.SystemsPages)
                        {
                            if (string.Equals(aspPage, childPage.AspPage, StringComparison.OrdinalIgnoreCase)
                                && string.Equals(aspArea, parentModule.AspArea, StringComparison.OrdinalIgnoreCase))
                            {
                                systemsPage = childPage;
                                isRegistered = true;
                                break;
                            }
                        }
                    }
                    if (isRegistered) { break; }
                }
            }
        }
        return systemsPage;
    }

    private ModuleTheme GetModuleCustomization(string moduleId)
    {
        IEnumerable<SystemsModule> allModules = GetAllModules;
        SystemsModule module = GetModule(moduleId);
        // Set Default Module Settings
        bool isParentMenuItem = true;
        if (module.ParentModuleId != null)
        {
            isParentMenuItem = !allModules.Any(m => m.SystemsModuleID == module.ParentModuleId);
        }
        string moduleShortName = GetModuleShortName(module);
        string moduleImgUrl = _ModuleImageFolder + module.ModuleImageFile;
        string moduleMainClass = _ModuleThemePrefix + moduleShortName;
        // Toggle Modules On/Off
        bool isVisibleMenuItem = true;

        ModuleTheme customModuleSettings = new()
        {
            ModuleShortName = moduleShortName,
            ModuleImgUrl = moduleImgUrl,
            ModuleMainClass = moduleMainClass,
            IsParentMenuItem = isParentMenuItem,
            IsVisibleMenuItem = isVisibleMenuItem
        };
        return customModuleSettings;
    }

    private string GetModuleShortName(SystemsModule module)
    {
        string moduleShortName = _DefaultModuleName;
        if (module.Name is string longModuleName) { moduleShortName = longModuleName; }
        if (moduleShortName.Contains(' ')) { moduleShortName = moduleShortName.Replace(" ", "-"); }
        moduleShortName = moduleShortName.ToLower().Trim();
        return moduleShortName;
    }

    public ModulePageLinks GetPageLinksByRequest(HttpRequest httpRequest)
    {
        var routeValues = httpRequest.RouteValues;
        var aspPage = string.Empty;
        if (routeValues["page"] != null)
        {
            aspPage = routeValues["page"]!.ToString();
            if (aspPage != null && aspPage.Contains('/'))
            {
                aspPage = aspPage[(aspPage.LastIndexOf('/') + 1)..];
            }
        }
        var aspArea = string.Empty;
        if (routeValues["area"] != null)
        {
            aspArea = routeValues["area"]!.ToString();
        }
        SystemsPage page = GetPageByArea(aspArea, aspPage);
        ModulePageLinks modulePageLinks = GetModulePageLinks(page.SystemsModuleId);
        return modulePageLinks;
    }

    private ModulePageLinks GetModulePageLinks(string moduleId)
    {
        ModulePageLinks pageLinks = new();
        SystemsModule module = GetModule(moduleId);
        pageLinks.ModuleName = module.Name;
        if (module.ParentModuleId != null)
        {
            pageLinks.ModuleName = GetModule(module.ParentModuleId).Name;
        }
        List<SystemsPage> modulePages = [.. GetAllPages.Where(p => p.SystemsModuleId == moduleId)];
        foreach (SystemsPage page in modulePages)
        {
            pageLinks.ModulePages.Add(page.AspPage, new ModulePage
            {
                Title = page.Title,
                Description = page.Description,
                Url = page.AspParentFolder + "/" + page.AspPage
            });
        }
        return pageLinks;
    }
}
