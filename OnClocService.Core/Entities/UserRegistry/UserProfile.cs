#nullable disable

using Microsoft.AspNetCore.Identity;
using OnClocService.Core.Entities.CustomerRegistry;
using OnClocService.Core.Entities.Systems;
using OnClocService.Core.Entities.TechnicianRegistry;
using OnClocService.Core.EntityBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnClocService.Core.Entities.UserRegistry;

public class SystemsUser : IdentityUser<Guid>
{
    public Guid SystemsBusinessProfileId { get; set; }

    // Properties
    [Display(Name = "First FileName")]
    public string FirstName { get; set; }

    [Display(Name = "Last FileName")]
    public string LastName { get; set; }

    [Display(Name = "Full Names")]
    public string FullNames { get { return LastName + " " + FirstName; } }

    [Display(Name = "Avator File Url")]
    public string AvatorFileUrl { get; set; } = "img/profile/default-avator.png";

    [Display(Name = "System User Account")]
    public bool IsBuiltInSystemsUser { get; set; } = false;

    // Tracking
    [ForeignKey(nameof(SystemsBusinessProfileId))]
    public SystemsBusinessProfile SystemsBusinessProfile { get; set; }

    // Navigation
    public virtual ICollection<SystemsUserLogin> Logins { get; set; }
    public virtual ICollection<SystemsUserToken> Tokens { get; set; }
    public virtual ICollection<SystemsUserClaim> UserClaims { get; set; }
    public virtual ICollection<SystemsUserRole> UserRoles { get; set; }
    public ICollection<SystemsUserDevice> SystemsUserDevices { get; set; }
    public ICollection<SystemsActivityLog> SystemsActivityLogs { get; set; }
    public ICollection<SystemsUserNotification> SystemsUserNotifications { get; set; }
    public ICollection<ServiceOfficerProfile> ServiceOfficerProfiles { get; set; }
    public ICollection<CustomerProfile> CustomerProfiles { get; set; }
}

public class SystemsRole : IdentityRole<Guid>
{
    // Properties
    [Display(Name = "Role Description")]
    public string RoleDescription { get; set; } = string.Empty;

    [Display(Name = "System Role")]
    public bool IsSystemRole { get; set; } = false;

    // Navigation
    public virtual ICollection<SystemsUserRole> UserRoles { get; set; }
    public virtual ICollection<SystemsRoleClaim> RoleClaims { get; set; }
    public virtual ICollection<SystemsRoleFunctionalRole> FunctionalRoles { get; set; }
}

public class SystemsRoleFunctionalRole : SystemsEntityBase
{
    [Key]
    public Guid RoleFunctionalRoleId { get; set; }
    public Guid RoleId { get; set; }
    public Guid FunctionalRoleId { get; set; }

    // Properties
    public int AuthorizationLevel { get; set; } = 0;

    // Tracking
    [ForeignKey(nameof(RoleId))]
    public SystemsRole Role { get; set; }

    [ForeignKey(nameof(FunctionalRoleId))]
    public SystemsFunctionalRole FunctionalRole { get; set; }
}

public class SystemsFunctionalRole : SystemsEntityBase
{
    [Key]
    public Guid FunctionalRoleId { get; set; }

    // Properties
    public required string Name { get; set; }
    public required string Description { get; set; }

    // Navigation
    public virtual ICollection<SystemsRoleFunctionalRole> FunctionalRoles { get; set; }
}

public class SystemsUserRole : IdentityUserRole<Guid>
{
    [ForeignKey("UserName")] 
    public virtual SystemsUser User { get; set; }

    [ForeignKey("RoleId")] 
    public virtual SystemsRole Role { get; set; }
}

public class SystemsUserLogin : IdentityUserLogin<Guid>
{
    [ForeignKey("UserName")] 
    public virtual SystemsUser User { get; set; }
}

public class SystemsUserToken : IdentityUserToken<Guid>
{
    [ForeignKey("UserName")] 
    public virtual SystemsUser User { get; set; }
}

public class SystemsUserClaim : IdentityUserClaim<Guid>
{
    [ForeignKey("UserName")] 
    public virtual SystemsUser User { get; set; }
}

public class SystemsRoleClaim : IdentityRoleClaim<Guid>
{
    [ForeignKey("RoleId")] 
    public virtual SystemsRole Role { get; set; }
}