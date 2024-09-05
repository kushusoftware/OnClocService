#nullable disable

using OnClocService.Core.EntityBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnClocService.Core.Entities.TicketRegistry;

public class ServiceTicketTaskStep : SystemsEntityBase
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid CustomerServiceTicketTaskStepID { get; set; }
    public Guid ServiceTicketTaskId { get; set; }

    // Properties
    public string StepsTaken { get; set; }
    public string Remarks { get; set; }

    // Tracking
    [ForeignKey(nameof(ServiceTicketTaskId))]
    public ServiceTicketTask ServiceTicketTask { get; set; }
}
