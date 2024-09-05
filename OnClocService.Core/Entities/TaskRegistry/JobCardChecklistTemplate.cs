#nullable disable

using OnClocService.Core.EntityBase;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnClocService.Core.Entities.TaskRegistry;

public class JobCardChecklistTemplate : SystemsEntityBase
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int JobCardChecklistTemplateID { get; set; }

    // Properties
    public string TemplateName { get; set; }
    public string TemplateDescription { get; set; }
    public string ChecklistName { get; set; } = "Default Checklist (change to custom name)";
    public string ChecklistDescription { get; set; } = "Default Description (change to custom description";

    // Navigation
    public ICollection<JobCardChecklist> JobCardChecklists { get; set; }
    public ICollection<JobCardChecklistTemplateTask> JobCardChecklistTemplateTasks { get; set; }
}
