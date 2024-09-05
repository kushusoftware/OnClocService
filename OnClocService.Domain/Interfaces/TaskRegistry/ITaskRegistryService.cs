using OnClocService.Core.Entities.TaskRegistry;
using OnClocService.Domain.DataModels.TaskRegistry;

namespace OnClocService.Domain.Interfaces.TaskRegistry
{
    public interface ITaskRegistryService
    {
        Task<GetJobTasksReponse> GetTasks();
        Task<GetChecklistResponse> GetTasksByChecklist(Guid checklistId);
        Task<GetChecklistTemplateResponse> GetTasksByTemplate(int templateId);
        Task<SaveJobTaskResponse> SaveTask(JobCardChecklist jobTask);
        Task<DeleteJobTasksResponse> DeleteTask(Guid jobTaskId, Guid userId);
    }
}
