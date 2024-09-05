#nullable disable

using OnClocService.Core.EntityBase;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using OnClocService.Core.Entities.TechnicianRegistry;

namespace OnClocService.Core.Entities.TicketRegistry;

public class ServiceTicketAllocation : SystemsEntityBase
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid ServiceTicketAllocationID { get; set; }
    public Guid ServiceTicketId { get; set; }
    public Guid ServiceDeskMemberId { get; set; }

    // Properties
    public DateTime AssignOnDate { get; set; }
    public TimeSpan ServiceLevelDuration { get; set; } = TimeSpan.FromDays(3);
    public DateTime DueOnDate => AssignOnDate.Add(ServiceLevelDuration);
    public bool IsAssigned { get; set; }

    // Tracking
    [ForeignKey(nameof(ServiceTicketId))]
    public ServiceTicket ServiceTicket { get; set; }

    [ForeignKey(nameof(ServiceDeskMemberId))]
    public ServiceDeskMember ServiceDeskMember { get; set; }

    // Navigation
    public ICollection<ServiceTicketTask> CustomerServiceTicketTasks { get; set; }
}
