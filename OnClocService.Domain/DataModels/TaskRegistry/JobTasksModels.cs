#nullable disable

using OnClocService.Core.Entities.TaskRegistry;
using System.Text.Json.Serialization;

namespace OnClocService.Domain.DataModels.TaskRegistry;

public class JobTaskRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime TimeStamp { get; set; }
    public bool IsCompleted { get; set; }
}

public class JobTaskResponse : ResponseBase
{
    public Guid JobTaskID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime TimeStamp { get; set; }
    public bool IsCompleted { get; set; }
}

public class GetJobTasksReponse : ResponseBase
{
    public List<JobTask> JobTasks { get; set; }
}

public class SaveJobTaskResponse : ResponseBase
{ 
    public JobTask JobTask { get; set; }
}

public class DeleteJobTasksResponse : ResponseBase 
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Guid JobTaskID { get; set; }
}