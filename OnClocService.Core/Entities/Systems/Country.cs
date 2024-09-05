#nullable disable

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnClocService.Core.Entities.Systems;

public class SystemsCountry
{
    [Key, StringLength(2)]
    public required string SystemsCountryID { get; set; }
    [StringLength(3)]
    public string SystemsCurrencyId { get; set; }

    // Properties
    [Display(Name = "Country FileName"), Required]
    public string SystemsCountryName { get; set; }

    [Display(Name = "Country Short Code"), StringLength(3)]
    public string SystemsCountryShortCode { get; set; }


    // Tracking
    [ForeignKey(nameof(SystemsCurrencyId))] 
    public SystemsCurrency SystemsCurrency { get; set; }

    // Navigation
    public ICollection<SystemsCity> SystemsCities { get; set; }
    public ICollection<SystemsContactDetail> SystemsContactDetails { get; set; }
    public ICollection<SystemsCountryPhoneCode> SystemsCountryPhoneCodes { get; set; }
}

public class SystemsCountryPhoneCode
{
    [Key]
    public Guid SystemsCountryPhoneCodeID { get; set; }
    [StringLength(2)]
    public string SystemsCountryId { get; set; }

    // Properties
    [Display(Name = "Country Phone Dial Code"), StringLength(10), Required]
    public required string SystemsCountryPhoneDialCode { get; set; }

    // Navigation
    [ForeignKey(nameof(SystemsCountryId))]
    public SystemsCountry SystemsCountry { get; set; }
}

public class SystemsCity
{
    [Key]
    public Guid SystemCityID { get; set; } = Guid.NewGuid();
    [StringLength(2)]
    public string SystemsCountryId { get; set; }

    // Properties
    [Display(Name = "City FileName"), Required]
    public string CityName { get; set; }

    [Display(Name = "City Description")]
    public string CityDescription { get; set; }

    // Tracking
    [ForeignKey(nameof(SystemsCountryId))]
    public SystemsCountry SystemsCountry { get; set; }

    // Navigation
    public ICollection<SystemsContactDetail> SystemsContactDetails { get; set; }
}
