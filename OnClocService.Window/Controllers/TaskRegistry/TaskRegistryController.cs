using Microsoft.AspNetCore.Mvc;
using OnClocService.Domain.Interfaces.TaskRegistry;

namespace OnClocService.Window.Controllers.TaskRegistry;

public class TaskRegistryController(ITaskRegistryService taskRegistry) : BaseController
{
    private readonly ITaskRegistryService _TaskRegistry = taskRegistry;

    [HttpGet]
    [Route("GetChecklistTasks")]
    public async Task<IActionResult> GetChecklistTasks(string checklistId)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        var getChecklistTasks = await _TaskRegistry.GetTasksByChecklist(Guid.Parse(checklistId));
        if (getChecklistTasks.Success)
        {
            return Ok(getChecklistTasks);
        }
        return Unauthorized();
    }
}
