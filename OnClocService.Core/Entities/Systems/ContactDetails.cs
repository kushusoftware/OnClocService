#nullable disable

using OnClocService.Core.Entities.CustomerRegistry;
using OnClocService.Core.Entities.TechnicianRegistry;
using OnClocService.Core.EntityBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnClocService.Core.Entities.Systems;

public class SystemsContactDetail : SystemsEntityBase
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid SystemsContactDetailID { get; set; }
    public Guid SystemCityId { get; set; }
    [StringLength(2)]
    public string SystemsCountryId { get; set; }

    // Properties
    [Display(Name = "Office Number")]
    public string OfficeNumber { get; set; }

    [Display(Name = "Shop Number")]
    public string ShopNumber { get; set; }

    [Display(Name = "Physical Address")]
    public string PhysicalAddress { get; set; }

    [Display(Name = "Street Name")]
    public string StreetName { get; set; }

    [Display(Name = "Postal Code")]
    public string PostalCode { get; set; }

    [Display(Name = "Email Address"), EmailAddress]
    public string EmailAddress { get; set; }

    [Display(Name = "Primary Phone Number"), Phone]
    public string PrimaryPhone { get; set; }

    [Display(Name = "Mobile Phone Number"), Phone]
    public string MobileNumber { get; set; }

    [Display(Name = "Secondary Phone Number"), Phone]
    public string SecondaryPhone { get; set; }

    [Display(Name = "Website Url"), Url]
    public string WebsiteUrl { get; set; }
    public bool IsPrimaryContact { get; set; }

    // Tracking
    [ForeignKey(nameof(SystemCityId))]
    public SystemsCity SystemsCity { get; set; }

    [ForeignKey(nameof(SystemsCountryId))]
    public SystemsCountry SystemsCountry { get; set; }

    // Navigation
    public ICollection<SystemsBusinessProfile> SystemsBusinessProfiles { get; set; }
    public ICollection<ServiceOfficerProfile> ServiceOfficerProfiles { get; set; }
    public ICollection<CustomerProfile> CustomerProfiles { get; set; }
}
