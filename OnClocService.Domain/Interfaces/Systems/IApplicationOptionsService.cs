
namespace OnClocService.Domain.Interfaces.Systems;

public interface IApplicationOptionsService
{
    Task<string> GetApplicationFullName();
    Task<string> GetApplicationShortName();
    Task<string> GetApplicationSlogan();
    Task<string> GetApplicationVersion();
    Task<string> GetApplicationDefaultPageSize();
    Task<string> GetApplicationIconUrl();
    Task<string> GetApplicationLogoUrl();
    Task<string> GetApplicationCopyright();
    Task<string> GetApplicationCopyrightUrl();
}
