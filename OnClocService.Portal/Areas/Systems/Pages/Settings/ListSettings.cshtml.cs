#nullable disable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OnClocService.Core.Attributes;
using OnClocService.Core.Constants;
using OnClocService.Core.Entities.Systems;
using OnClocService.Infrastructure.DataStorage;

namespace OnClocService.Portal.Areas.Systems.Pages.Settings;

[SystemsAuthorize(SysPolicy.Administrator, SysPrivilege.ReadRecord)]
public class ListSettingsModel(OnClocDataStorageContext storageContext) : PageModel
{
    private readonly OnClocDataStorageContext _StorageContext = storageContext;

    [BindProperty]
    public List<SystemsSettings> SystemSettings { get; set; }

    public async Task<IActionResult> OnGet()
    {
        SystemSettings = await GetAllSystemSettingsAsync();
        return Page();
    }

    private async Task<List<SystemsSettings>> GetAllSystemSettingsAsync() => await _StorageContext.SystemsSettings.ToListAsync();
}
