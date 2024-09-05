#nullable disable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnClocService.Core.Attributes;
using OnClocService.Core.Constants;
using OnClocService.Core.Entities.Systems;
using OnClocService.Domain.DataModels.Systems;
using OnClocService.Domain.Interfaces.Systems;
using OnClocService.Infrastructure.Extensions.Systems;
using OnClocService.Portal.Areas.Systems.PageViews;

namespace OnClocService.Portal.Areas.Systems.Pages.PageRegistry;

[SystemsAuthorize(SysPolicy.Inputter, SysPrivilege.WriteRecord)]
public class CreatePageModel(IPageManagerService pageManager) : PageModel
{
    private readonly IPageManagerService _PageManager = pageManager;
    private readonly string _MessageKey = "Feedback";

    [BindProperty]
    public PageProfile PageProfile { get; set; }
    public SelectList ModulesList { get; set; }
    public ModulePageLinks PageLinks { get; set; }

    public IActionResult OnGet()
    {
        var modulesListSelectedItem = "M0100";
        var httpRequest = PageContext.HttpContext.Request;
        PageLinks = _PageManager.GetPageLinksByRequest(httpRequest);
        ModulesList = _PageManager.GetOrderedListOfModules(modulesListSelectedItem);
        ViewData.Add("ListOfModules", ModulesList);
        return Page();
    }

    public async Task<IActionResult> OnPostCreateAsync()
    {

        var messageType = TemporaryStorage.MessageType.info;
        var messageText = "add new page ";

        if(!ModelState.IsValid)
        {
            messageText += "failed: invalid model";
            TemporaryStorage.AddFeedback(TempData, _MessageKey, messageType, messageText);
            return Page();
        }

        if (PageProfile == null)
        {
            messageText += "failed: details missing";
            messageType = TemporaryStorage.MessageType.warning;
            TemporaryStorage.AddFeedback(TempData, _MessageKey, messageType, messageText);
            return Page();
        }
        var selectedModuleId = PageProfile.SystemsModuleId;
        PredictedPageIdentifier predictedPage = _PageManager.GenerateNewPageIdentifier(selectedModuleId);
        var systemsPage = new SystemsPage() 
        {
            SystemsPageID = predictedPage.Id,
            Index = predictedPage.Index,
            SystemsModuleId = PageProfile.SystemsModuleId,
            AspParentFolder = PageProfile.ModuleFolder,
            AspPage = PageProfile.AspPage,
            Name = PageProfile.PageName,
            Title = PageProfile.PageTitle,
            Description = PageProfile.PageDescription ??= "",
            IconClass = PageProfile.IconClass ??= "",
            IsDefaultPage = PageProfile.IsDefaultPage,
            ShowInMenu = PageProfile.ShowInMenu,
            EnableMenuItem = PageProfile.EnableMenuItem
        };
        bool jobDone = await _PageManager.AddSystemsPageAsync(systemsPage);
        if (!jobDone)
        {
            messageText += "failed: data error";
            messageType = TemporaryStorage.MessageType.danger;
            TemporaryStorage.AddFeedback(TempData, _MessageKey, messageType, messageText);
            return Page();
        }

        messageText += "was successful";
        messageType = TemporaryStorage.MessageType.success;
        TemporaryStorage.AddFeedback(TempData, _MessageKey, messageType, messageText);
        var listPages = PageLinks.ModulePages["ListPages"].ToString();
        return RedirectToPage(listPages);
    }
}
