#nullable disable

using OnClocService.Core.Entities.UserRegistry;
using OnClocService.Core.EntityBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnClocService.Core.Entities.Systems;

public class SystemsBusinessProfile : SystemsEntityBase
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid SystemsBusinessID { get; set; }
    public Guid SystemsContactDetailId { get; set; }

    // Properties
    [Display(Name = "Business Fullname")]
    public string SystemsBusinessFullname { get; set; }

    [Display(Name = "Business Shortname")]
    public string SystemsBusinessShortname { get; set; }

    [Display(Name = "Business Logo Url")]
    public string SystemsBusinessLogoUrl { get; set; }

    [Display(Name = "RegistrationNumber")]
    public string RegistrationNumber { get; set; }

    [Display(Name = "Invoice Number Prefix")]
    public string InvoiceNumberPrefix { get; set; }

    [Display(Name = "Quote Number Prefix")]
    public string QuoteNumberPrefix { get; set; }

    [Display(Name = "Is VAT Registered")]
    public bool IsVatEnabled { get; set; }

    [Display(Name = "VAT Registration Number")]
    public string VatNumber { get; set; }

    [Display(Name = "Data Connection String")]
    public string DataConnectionString { get; set; }

    // Tracking
    [ForeignKey(nameof(SystemsContactDetailId))]
    public SystemsContactDetail SystemsContactDetail { get; set; }

    // Navigation
    public ICollection<SystemsBusinessCurrency> SystemsBusinessCurrencies { get; set; }
    public ICollection<SystemsBusinessLicense> SystemsBusinessLicenses { get; set; }
    public ICollection<SystemsUser> SystemsUsers { get; set; }
}

public class SystemsBusinessLicense : SystemsEntityBase
{
    [Key]
    public Guid SystemsBusinessLicenseID { get; set; }
    public Guid SystemsBusinessProfileId { get; set; }

    // Properties
    [Display(Name = "License LicenseName")]
    public string LicenseName { get; set; }

    [Display(Name = "License Key")]
    public string LicenseKey { get; set; }

    [Display(Name = "License Start")]
    public DateTime LicenseStart { get; set; }

    [Display(Name = "License Expiry")]
    public DateTime LicenseExpiry { get; set; }

    // Tracking
    [ForeignKey(nameof(SystemsBusinessProfileId))] 
    public SystemsBusinessProfile SystemsBusinessProfile { get; set; }
}
