#nullable disable

using OnClocService.Core.EntityBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnClocService.Core.Entities.PaymentRegistry;

public class TaxationType : SystemsEntityBase
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TaxationTypeID { get; set; }

    // Properties
    public string TaxationName { get; set; }
    public string TaxationRate { get; set; } // not used to calculate but string to display

    // Navigation
    public ICollection<CustomerInvoiceTaxation> CustomerInvoiceTaxations { get; set; }
}
