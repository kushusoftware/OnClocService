#nullable disable

using OnClocService.Core.EntityBase;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnClocService.Core.Entities.TaskRegistry;

public class JobCardChecklistTemplateTask : SystemsEntityBase
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid JobCardChecklistTemplateTaskID { get; set; }
    public int JobCardChecklistTemplateId { get; set; }
    public Guid JobTaskId { get; set; }

    // Tracking
    [ForeignKey(nameof(JobCardChecklistTemplateId))]
    public JobCardChecklistTemplate JobCardChecklistTemplate { get; set; }

    [ForeignKey(nameof(JobTaskId))]
    public JobTask JobTask { get; set; }
}