#nullable disable

namespace OnClocService.Domain.DataModels.Systems;

public class PageNavigation
{
    public string ActivePageAria = "page";

    public string ActivePageClass = "active";
    public string ModuleShortName { get; set; } = "";
    public string ModuleMainClass { get; set; } = "";
    public string ModuleImgUrl { get; set; }
    public IList<BreadcrumbItem> BreadcrumbItems { get; set; } = [];
}

public class NavigationMenuParentItem
{
    public required string MenuItemID { get; set; }
    public string MenuParentID { get; set; }
    public int MenuItemIndex { get; set; }
    public required string ModuleName { get; set; }
    public required string ModuleShortName { get; set; }
    public required string ModuleTitle { get; set; }
    public string ModuleIconClass { get; set; }
    public string ModuleImageUrl { get; set; }
    public string ModuleMainClass { get; set; }
    public bool IsDefaultModule { get; set; }
    public bool IsParentMenuItem { get; set; }
    public bool IsVisibleMenuItem { get; set; }
    public bool IsActiveMenuItem { get; set; }
    public List<NavigationMenuChildItem> ChildMenuItems { get; set; } = [];
}

public class NavigationMenuChildItem
{
    public required string MenuItemID { get; set; }
    public string MenuParentItemID { get; set; }
    public int MenuItemIndex { get; set; }
    public required string MenuItemName { get; set; }
    public required string MenuItemTitle { get; set; }
    public string MenuItemAspArea { get; set; }
    public required string MenuItemAspPage { get; set; }
    public string MenuItemIconClass { get; set; }
    public bool IsActiveMenuItem { get; set; }
    public bool IsVisibleMenuItem { get; set; }
    public bool IsDefaultModuleItem { get; set; }
}

public class BreadcrumbItem
{
    public string AspArea { get; set; }
    public required string AspPage { get; set; }
    public required string PageIconClass { get; set; }
    public required string PageTitle { get; set; }
    public required string PageDescription { get; set; }
    public bool IsActivePage { get; set; }
}
