#nullable disable

using OnClocService.Core.Entities.TicketRegistry;
using OnClocService.Core.EntityBase;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnClocService.Core.Entities.CustomerRegistry;

public class CustomerServiceTicket : SystemsEntityBase
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid CustomerServiceTicketID { get; set; }
    public Guid CustomerProfileId { get; set; }
    public Guid ServiceTicketId { get; set; }

    // Properties
    public double ServiceRating { get; set; }
    public bool IsClosed => ServiceRating > 0;

    // Tracking
    [ForeignKey(nameof(CustomerProfileId))]
    public CustomerProfile CustomerProfile { get; set; }

    [ForeignKey(nameof(ServiceTicketId))]
    public ServiceTicket ServiceTicket { get; set; }

    // Navigation
    public ICollection<CustomerServiceRating> CustomerServiceRatings { get; set; }
}
