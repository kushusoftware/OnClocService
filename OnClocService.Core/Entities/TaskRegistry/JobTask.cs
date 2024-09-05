#nullable disable

using OnClocService.Core.EntityBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnClocService.Core.Entities.TaskRegistry
{
    public class JobTask : SystemsEntityBase
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid JobTaskID { get; set; }

        // Properties
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public DateTime TaskStart { get; set; }
        public DateTime TaskEnd { get; set; }
        public TimeSpan TaskDuration { get; set; }
        public bool IsCompleted { get; set; }

        // Navigation
        public ICollection<JobTaskStep> JobTaskSteps { get; set; }
        public ICollection<JobCardChecklistTask> JobCardChecklistTasks{ get; set; }
        public ICollection<JobCardChecklistTemplateTask> JobCardChecklistTemplateTasks { get; set; }
    }
}
