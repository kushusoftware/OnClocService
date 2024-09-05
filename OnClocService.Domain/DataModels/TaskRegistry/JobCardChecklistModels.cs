#nullable disable

using OnClocService.Core.Entities.TaskRegistry;

namespace OnClocService.Domain.DataModels.TaskRegistry;

public class GetChecklistResponse : ResponseBase
{
    public string ChecklistName { get; set; }
    public string ChecklistDescription { get; set; }
    public TimeSpan ChecklistDuration { get; set; }
    public List<JobTask> Tasks { get; set; }
}

public class GetChecklistTemplateResponse : ResponseBase
{
    public string ChecklistName { get; set; }
    public string ChecklistDescription { get; set; }
    public List<JobTask> Tasks { get; set; }
}
