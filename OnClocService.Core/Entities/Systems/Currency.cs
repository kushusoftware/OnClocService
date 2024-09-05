#nullable disable

using OnClocService.Core.Entities.PaymentRegistry;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnClocService.Core.Entities.Systems;

public class SystemsCurrency
{
    [Key, StringLength(3)]
    public string SystemsCurrencyID { get; set; }

    // Properties
    [Display(Name = "Currency FileName")]
    public required string SystemsCurrencyName { get; set; }

    [Display(Name = "Currency Symbol")]
    public string SystemsCurrencySymbol { get; set; }

    [Display(Name = "Prefix the Currency Symbol")]
    public bool PrefixCurrencySymbol { get; set; } = true;

    [Display(Name = "Surfix the Currency Symbol")]
    public bool SurfixCurrencySymbol { get; set; } = false;

    // Navigation
    public ICollection<SystemsCountry> SystemsCountries { get; set; }
}

public class SystemsBusinessCurrency
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid SystemsBusinessCurrencyID { get; set; }
    public Guid SystemsBusinessProfileId { get; set; }
    [StringLength(3)]
    public string SystemsCurrencyId { get; set; }

    /// <summary>
    /// Remember to handle default base currency check in business logic
    /// </summary>
    [Display(Name = "Set As Business Base Currency")]
    public bool IsBaseCurrency { get; set; } = false;

    // Tracking
    [ForeignKey(nameof(SystemsCurrencyId))]
    public SystemsCurrency SystemsCurrency { get; set; }

    [ForeignKey(nameof(SystemsBusinessProfileId))]
    public SystemsBusinessProfile SystemsBusinessProfile { get; set; }

    // Navigation
    public ICollection<CustomerInvoice> CustomerInvoices { get; set; }
    public ICollection<CustomerPayment> CustomerPayments { get; set; }
}
