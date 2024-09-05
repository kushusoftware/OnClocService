using OnClocService.Domain.Interfaces.Systems;

namespace OnClocService.Infrastructure.Services.Systems;

public class ApplicationOptionsService(IApplicationOptionsService applicationOptions)
{
    public async Task<string> GetFullName() => await applicationOptions.GetApplicationFullName();
    public async Task<string> GetShortName() => await applicationOptions.GetApplicationShortName();
    public async Task<string> GetSlogan() => await applicationOptions.GetApplicationSlogan();
    public async Task<string> GetVersion() => await applicationOptions.GetApplicationVersion();
    public async Task<string> GetDefaultPageSize() => await applicationOptions.GetApplicationDefaultPageSize();
    public async Task<string> GetIconUrl() => await applicationOptions.GetApplicationIconUrl();
    public async Task<string> GetLogoUrl() => await applicationOptions.GetApplicationLogoUrl();
    public async Task<string> GetCopyright() => await applicationOptions.GetApplicationCopyright();
    public async Task<string> GetCopyrightUrl() => await applicationOptions.GetApplicationCopyrightUrl();
}
