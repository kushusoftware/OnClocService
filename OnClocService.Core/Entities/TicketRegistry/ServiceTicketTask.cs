#nullable disable

using OnClocService.Core.Entities.TechnicianRegistry;
using OnClocService.Core.EntityBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnClocService.Core.Entities.TicketRegistry;

public class ServiceTicketTask : SystemsEntityBase
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid ServiceTicketTaskID { get; set; }
    public Guid ServiceTicketId { get; set; }
    public Guid ServiceOfficerProfileId { get; set; }

    // Properties
    public DateTime TaskStarted { get; set; }
    public DateTime TaskCompleted { get; set; }
    public TimeSpan TaskDuration => TaskCompleted - TaskStarted;
    public string TechnicalRemarks { get; set; }
    public bool IsCompleted { get; set; }

    // Tracking
    [ForeignKey(nameof(ServiceTicketId))]
    public ServiceTicket ServiceTicket { get; set; }

    [ForeignKey(nameof(ServiceOfficerProfileId))]
    public ServiceOfficerProfile ServiceOfficerProfile { get; set; }

    // Navigation
    public ICollection<ServiceTicketTaskStep> ServiceTicketTaskSteps { get; set; }
}
