#nullable disable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OnClocService.Core.Attributes;
using OnClocService.Core.Constants;
using OnClocService.Core.Entities.Systems;
using OnClocService.Domain.DataModels.Systems;
using OnClocService.Domain.Interfaces.Systems;
using OnClocService.Infrastructure.Extensions.Systems;

namespace OnClocService.Portal.Areas.Systems.Pages.PageRegistry;

[SystemsAuthorize(SysPolicy.Observer, SysPrivilege.ReadRecord)]
public class ListPagesModel(IPageManagerService pageManager, IOptions<SystemsApplicationOptions> applicationOptions) : PageModel
{
    private readonly IPageManagerService _PageManager = pageManager;
    private readonly IOptions<SystemsApplicationOptions> _ApplicationOptions = applicationOptions;

    internal string PageFileSort { get; set; }
    internal string PageNameSort { get; set; }
    internal string PageFilter { get; set; }
    internal string PageSort { get; set; }
    internal PaginatedList<SystemsPage> ListPages { get; set; }
    internal ModulePageLinks PageLinks { get; set; }

    public async Task<IActionResult> OnGetAsync(string sortBy, string findBy, string filterBy, int? pageIndex)
    {
        PageLinks = _PageManager.GetPageLinksByRequest(PageContext.HttpContext.Request);
        var systemPages = _PageManager.GetAllPages;
        if (systemPages.Any())
        {
            PageSort = sortBy;
            PageFileSort = string.IsNullOrEmpty(sortBy) ? "name_descend" : "";
            PageNameSort = sortBy == "Page" ? "page_descend" : "Page";

            if (findBy != null) { pageIndex = 1; } else { findBy = filterBy; }
            filterBy = findBy;
            IQueryable<SystemsPage> pageIquery = from p in systemPages select p;
            if (!string.IsNullOrEmpty(filterBy))
            {
                pageIquery = filterBy switch
                {
                    "hidden" => pageIquery.Where(p => p.ShowInMenu == false),
                    "primary" => pageIquery.Where(p => p.IsDefaultPage == true),
                    "disabled" => pageIquery.Where(p => p.EnableMenuItem == false),
                    _ => pageIquery.Where(p => p.Name.Contains(filterBy) || p.AspPage.Contains(filterBy))
                };
            }

            pageIquery = sortBy switch
            {
                "page_descend" => pageIquery.OrderByDescending(p => p.AspPage),
                "Page" => pageIquery.OrderBy(p => p.AspPage),
                "name_descend" => pageIquery.OrderByDescending(p => p.Name),
                _ => pageIquery.OrderBy(p => p.Name)
            };

            var pageSize = int.Parse(_ApplicationOptions.Value.DefaultPageSize);
            ListPages = await PaginatedList<SystemsPage>.CreatePaginationAsync(pageIquery
                .AsNoTracking().Include(b => b.SystemsModule), pageIndex ?? 1, pageSize);
        }
        return Page();
    }
}
