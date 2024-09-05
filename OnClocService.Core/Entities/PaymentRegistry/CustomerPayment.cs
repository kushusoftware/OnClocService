#nullable disable

using OnClocService.Core.Entities.Systems;
using OnClocService.Core.EntityBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnClocService.Core.Entities.PaymentRegistry;

public class CustomerPayment : SystemsEntityBase
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid CustomerPaymentID { get; set; }
    public Guid SystemsBusinessProfileId { get; set; }
    public int PaymentMethodId { get; set; }

    // Properties
    public required DateTime PaymentDate { get; set; }
    public string InvoiceNumber { get; set; }
    public double TotalAmountDue { get; set; }
    public required double TotalPaidAmount { get; set; }

    // Tracking
    [ForeignKey(nameof(SystemsBusinessProfileId))]
    public SystemsBusinessProfile SystemsBusinessProfile { get; set; }

    [ForeignKey(nameof(PaymentMethodId))]
    public PaymentMethod PaymentMethod { get; set; }
}
