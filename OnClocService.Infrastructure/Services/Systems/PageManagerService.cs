using Microsoft.AspNetCore.Mvc.Rendering;
using OnClocService.Domain.Interfaces.Systems;
using OnClocService.Domain.DataModels.Systems;
using Microsoft.AspNetCore.Http;

namespace OnClocService.Infrastructure.Services.Systems;

public class PageManagerService(IPageManagerService pageManagerService)
{
    public string GetPageTitle(ViewContext viewContext) => pageManagerService.GetPageTitle(viewContext.HttpContext.Request);
    public PageNavigation GetPageCustomization(ViewContext viewContext) => pageManagerService.GetCurrentPageCustomization(viewContext.HttpContext.Request);
}