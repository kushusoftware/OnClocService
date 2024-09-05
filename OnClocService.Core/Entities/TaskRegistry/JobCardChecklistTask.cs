#nullable disable

using OnClocService.Core.Entities.ProjectRegistry;
using OnClocService.Core.Entities.TechnicianRegistry;
using OnClocService.Core.EntityBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnClocService.Core.Entities.TaskRegistry;

public class JobCardChecklistTask : SystemsEntityBase
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid JobCardChecklistTaskID { get; set; }
    public Guid ServiceOfficerProfileId { get; set; }
    public Guid JobCardChecklistId { get; set; }
    public Guid JobTaskId { get; set; }

    // Properties
    public DateTime TaskStarted { get; set; }
    public DateTime TaskCompleted { get; set; }
    public TimeSpan TaskDuration => TaskCompleted - TaskStarted;
    public string TechnicalRemarks { get; set; }
    public bool IsCompleted { get; set; }

    // Tracking
    [ForeignKey(nameof(ServiceOfficerProfileId))]
    public ServiceOfficerProfile ServiceOfficerProfile { get; set; }

    [ForeignKey(nameof(JobCardChecklistId))]
    public JobCardChecklist JobCardChecklist { get; set; }

    [ForeignKey(nameof(JobTaskId))]
    public JobTask JobTask { get; set; }
}
