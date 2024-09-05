namespace OnClocService.Portal.Areas.Systems.Extensions;

public static class WebAppBuilderExtensions
{
    public static void AddPortalPresentation(this WebApplicationBuilder builder)
    {
        builder.Services.AddRazorPages(options =>
        {
            options.Conventions.AllowAnonymousToAreaFolder("Identity", "/Account");
        }).AddSessionStateTempDataProvider();
    }
}
