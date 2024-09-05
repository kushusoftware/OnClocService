#nullable disable

using OnClocService.Core.Entities.Systems;
using OnClocService.Core.EntityBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnClocService.Core.Entities.PaymentRegistry;

public class CustomerInvoice : SystemsEntityBase
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid CustomerInvoiceID { get; set; }
    public Guid SystemsBusinessProfileId { get; set; }

    // Properties
    public required DateTime InvoiceDate { get; set; }
    public string InvoiceNumber { get; set; }
    public double TotalTaxDue { get; set; }
    public required double TotalInvoiceAmount { get; set; }

    // Tracking
    [ForeignKey(nameof(SystemsBusinessProfileId))]
    public SystemsBusinessProfile SystemsBusinessProfile { get; set; }

    // Navigation
    public ICollection<CustomerInvoiceTaxation> CustomerInvoiceTaxations { get; set; }
}

public class CustomerInvoiceTaxation : SystemsEntityBase
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid CustomerInvoiceTaxationID { get; set; }
    public Guid CustomerInvoiceId { get; set; }
    public int TaxationTypeId { get; set; }

    // Properties
    public double TaxableAmount { get; set; }
    public double TaxDue { get; set; }

    // Tracking
    [ForeignKey(nameof(CustomerInvoiceId))]
    public CustomerInvoice CustomerInvoice {  get; set; }

    [ForeignKey(nameof(TaxationTypeId))]
    public TaxationType TaxationType { get; set; }
}
