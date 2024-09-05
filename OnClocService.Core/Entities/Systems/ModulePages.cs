#nullable disable

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OnClocService.Core.EntityBase;

namespace OnClocService.Core.Entities.Systems;

public class SystemsPage : PageNavigationBase
{
    [Key, StringLength(10)]
    public string SystemsPageID { get; set; }
    [StringLength(10)]
    public string SystemsModuleId { get; set; }

    // Properties
    [Display(Name = "Default"), Required]
    public bool IsDefaultPage { get; set; } = false;

    [Display(Name = "File"), Required]
    public string AspPage { get; set; } = "Index";

    [Display(Name = "Folder")]
    public string AspParentFolder { get; set; }


    // Tracking
    [ForeignKey(nameof(SystemsModuleId))] 
    public SystemsModule SystemsModule { get; set; }

    // Navigation
    public ICollection<SystemsAuditEvent> SystemsAuditEvents { get; set; }
}

public class SystemsModule : PageNavigationBase
{
    [Key, StringLength(10)]
    public string SystemsModuleID { get; set; }
    public string ParentModuleId { get; set; }

    // Properties
    [Display(Name = "Default"), Required]
    public bool IsDefaultModule { get; set; } = false;

    [Display(Name = "Area")]
    public string AspArea { get; set; }

    [Display(Name = "Banner")]
    public string ModuleImageFile { get; set; }

    // Navigation
    public ICollection<SystemsPage> SystemsPages { get; set; }
    public ICollection<SystemsAuditEvent> SystemsAuditEvents { get; set; }
}
