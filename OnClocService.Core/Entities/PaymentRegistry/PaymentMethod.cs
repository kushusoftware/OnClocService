#nullable disable

using OnClocService.Core.EntityBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnClocService.Core.Entities.PaymentRegistry;

public class PaymentMethod : SystemsEntityBase
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PaymentMethodID { get; set; }

    // Properties
    public string PaymentMethodName { get; set; }

    // Navigation
    public ICollection<CustomerPayment> CustomerPayments { get; set; }
}
