#nullable disable

using System.ComponentModel.DataAnnotations;

namespace OnClocService.Portal.Areas.Systems.PageViews;

public class PageProfile
{
    [Display(Name = "List Index")]
    public int ListIndex { get; set; } = 0;

    [Display(Name = "Page ID")]
    public string SystemsPageId { get; set; }

    [Display(Name = "Associated Module"), Required]
    public string SystemsModuleId { get; set; }

    [Display(Name = "Module Folder")]
    [RegularExpression(@"^{'/'}[A-Z][a-zA-Z0-9'-']$", ErrorMessage = "folder name must start with '/' and cannot contain spaces")]
    public string ModuleFolder { get; set; }

    [Display(Name = "File Name"), Required]
    [RegularExpression(@"^[A-Z][a-z''-']$", ErrorMessage = "file name can only contain letters")]
    public string AspPage { get; set; }

    [Display(Name = "Page Name"), Required]
    public string PageName { get; set; }

    [Display(Name = "Page Title"), Required]
    public string PageTitle { get; set; }

    [Display(Name = "Page Description"), Required]
    public string PageDescription { get; set; }

    [Display(Name = "Icon Class")]
    public string IconClass { get; set; }

    [Display(Name = "Default Page")]
    public bool IsDefaultPage { get; set; }

    [Display(Name = "Show In Menu")]
    public bool ShowInMenu { get; set; }

    [Display(Name = "Enable Item")]
    public bool EnableMenuItem { get; set; }
}
