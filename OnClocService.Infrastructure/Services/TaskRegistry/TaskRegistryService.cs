using Microsoft.EntityFrameworkCore;
using OnClocService.Core.Entities.TaskRegistry;
using OnClocService.Domain.DataModels.TaskRegistry;
using OnClocService.Domain.Interfaces.TaskRegistry;
using OnClocService.Infrastructure.DataStorage;

namespace OnClocService.Infrastructure.Services.TaskRegistry
{
    public class TaskRegistryService(OnClocDataStorageContext storageContext) : ITaskRegistryService
    {
        private readonly OnClocDataStorageContext _StorageContext = storageContext;

        public Task<DeleteJobTasksResponse> DeleteTask(Guid jobTaskId, Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<GetJobTasksReponse> GetTasks()
        {
            var allTasks = await _StorageContext.JobTasks.ToListAsync();
            if (allTasks.Count == 0)
            {
                return new GetJobTasksReponse
                {
                    ErrorCode = "OIST0101",
                    ErrorMessage = "no tasks found for user"
                };
            }
            return new GetJobTasksReponse
            {
                Success = true,
                JobTasks = allTasks
            };
        }

        public async Task<GetChecklistResponse> GetTasksByChecklist(Guid checklistId)
        {
            var response = new GetChecklistResponse();
            var jobCardChecklists = await _StorageContext.JobCardChecklists
                .Where(j => j.JobCardChecklistID == checklistId)
                .Include(j => j.JobCardChecklistTasks)
                .ToListAsync();
            if (jobCardChecklists.Count == 0)
            {
                return new GetChecklistResponse
                {
                    ErrorCode = "OIST0102",
                    ErrorMessage = "no checklist found with checklistId"
                };
            }
            var jobCardChecklist = jobCardChecklists.SingleOrDefault();
            if (jobCardChecklist != null)
            {
                var tasks = new List<JobTask>();
                TimeSpan checklistDuration = TimeSpan.Zero;
                var jobCardTasks = jobCardChecklist.JobCardChecklistTasks;
                foreach (var jobCardTask in jobCardTasks)
                {
                    var task = jobCardTask.JobTask;
                    checklistDuration.Add(task.TaskDuration);
                    tasks.Add(task);
                }
                response.Success = true;
                response.ChecklistName = jobCardChecklist.ChecklistName;
                response.ChecklistDescription = jobCardChecklist.ChecklistDescription;
                response.ChecklistDuration = checklistDuration;
                response.Tasks = tasks;
            }
            return response;
        }

        public async Task<GetChecklistTemplateResponse> GetTasksByTemplate(int templateId)
        {
            var response = new GetChecklistTemplateResponse();
            var jobCardTemplates = await _StorageContext.JobCardChecklistTemplates
                .Where(t => t.JobCardChecklistTemplateID == templateId)
                .Include(t => t.JobCardChecklistTemplateTasks)
                .ToListAsync();
            var jobCardTemplate = jobCardTemplates.SingleOrDefault();
            if (jobCardTemplate != null)
            {
                var tasks = new List<JobTask>();
                var jobCardTasks = jobCardTemplate.JobCardChecklistTemplateTasks;
                foreach (var jobCardTask in jobCardTasks)
                {
                    var task = jobCardTask.JobTask;
                    tasks.Add(task);
                }
                response.Success = true;
                response.ChecklistName = jobCardTemplate.ChecklistName;
                response.ChecklistDescription = jobCardTemplate.ChecklistDescription;
                response.Tasks = tasks;
            }
            return response;
        }

        public Task<SaveJobTaskResponse> SaveTask(JobCardChecklist jobTask)
        {
            throw new NotImplementedException();
        }
    }
}
