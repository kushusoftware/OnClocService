#nullable disable

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnClocService.Core.Entities.TicketRegistry;

public class ServiceTicketStatus
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ServiceTicketStatusID { get; set; }

    // Properties
    [StringLength(100)]
    public string Status { get; set; }
    public string ColourCode { get; set; }

    // Navigation
    public ICollection<ServiceTicket> ServiceTickets { get; set; }
}
