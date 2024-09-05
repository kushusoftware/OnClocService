#nullable disable

using OnClocService.Core.Entities.ProjectRegistry;
using OnClocService.Core.EntityBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnClocService.Core.Entities.TaskRegistry;

public class JobCardChecklist : SystemsEntityBase
{
    [Key , DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid JobCardChecklistID { get; set; }
    public int JobCardChecklistTemplateId { get; set; }
    public Guid JobCardId { get; set; }

    // Properties
    public string ChecklistName { get; set; }
    public string ChecklistDescription { get; set; }
    public TimeSpan ChecklistDuration { get; set; }

    // Tracking
    [ForeignKey(nameof(JobCardId))]
    public JobCard JobCard { get; set; }

    [ForeignKey(nameof(JobCardChecklistTemplateId))]
    public JobCardChecklistTemplate JobCardChecklistTemplate { get; set; }

    // Navigation
    public ICollection<JobCardChecklistTask> JobCardChecklistTasks { get; set; }
}
