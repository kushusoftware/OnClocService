#nullable disable

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnClocService.Core.Entities.TicketRegistry;

public class ServiceTicketPriorityLevel
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ServiceTicketPriorityLevelID { get; set; }

    // Properties
    public int PriorityIndex { get; set; }
    public string PriorityLevel { get; set; }
    public string ColourCode { get; set; }
    public bool AllowEscalation { get; set; }
    public TimeSpan EscalationTime { get; set; }
    public bool IsDefault { get; set; }

    // Navigation
    public ICollection<ServiceTicket> ServiceTickets { get; set; }
}
