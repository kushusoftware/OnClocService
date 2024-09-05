#nullable disable

using OnClocService.Core.EntityBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnClocService.Core.Entities.TaskRegistry;

public class JobTaskStep : SystemsEntityBase
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid JobTaskStepID { get; set; }
    public Guid JobTaskId { get; set; }

    // Properties
    public string StepTitle {  get; set; }
    public string StepDescription { get; set; }       

    // Tracking
    [ForeignKey(nameof(JobTaskId))]
    public JobTask JobTask { get; set; }
}
