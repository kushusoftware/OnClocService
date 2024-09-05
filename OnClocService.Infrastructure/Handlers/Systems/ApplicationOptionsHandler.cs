

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OnClocService.Domain.DataModels.Systems;
using OnClocService.Domain.Interfaces.Systems;
using OnClocService.Infrastructure.DataStorage;

namespace OnClocService.Infrastructure.Handlers.Systems;

internal class ApplicationOptionsHandler(OnClocDataStorageContext storageContext, IOptions<SystemsApplicationOptions> applicaitonOptionsAccessor) : IApplicationOptionsService
{
    private readonly OnClocDataStorageContext _StorageContext = storageContext;
    private readonly IOptions<SystemsApplicationOptions> _ApplicationOptions = applicaitonOptionsAccessor;

    public async Task<string> GetApplicationFullName()
    {
        if (string.IsNullOrEmpty(_ApplicationOptions.Value.FullName))
        {
            string searchKey = "Application:FullName";
            return await GetSystemsSettingsAsync(searchKey);
        }
        else return _ApplicationOptions.Value.FullName;
    }

    public async Task<string> GetApplicationShortName()
    {
        if (string.IsNullOrEmpty(_ApplicationOptions.Value.ShortName))
        {
            string searchKey = "Application:ShortName";
            return await GetSystemsSettingsAsync(searchKey);
        }
        else return _ApplicationOptions.Value.ShortName;
    }

    public async Task<string> GetApplicationSlogan()
    {
        if (string.IsNullOrEmpty(_ApplicationOptions.Value.Slogan))
        {
            string searchKey = "Application:Slogan";
            return await GetSystemsSettingsAsync(searchKey);
        }
        else return _ApplicationOptions.Value.Slogan;
    }

    public async Task<string> GetApplicationVersion()
    {
        if (string.IsNullOrEmpty(_ApplicationOptions.Value.Version))
        {
            string searchKey = "Application:Version";
            return await GetSystemsSettingsAsync(searchKey);
        }
        else return _ApplicationOptions.Value.Version;
    }

    public async Task<string> GetApplicationDefaultPageSize()
    {
        if (string.IsNullOrEmpty(_ApplicationOptions.Value.DefaultPageSize))
        {
            string searchKey = "Application:DefaultPageSize";
            return await GetSystemsSettingsAsync(searchKey);
        }
        else return _ApplicationOptions.Value.DefaultPageSize;
    }

    public async Task<string> GetApplicationIconUrl()
    {
        if (string.IsNullOrEmpty(_ApplicationOptions.Value.IconUrl))
        {
            string searchKey = "Application:IconUrl";
            return await GetSystemsSettingsAsync(searchKey);
        }
        else return _ApplicationOptions.Value.IconUrl;
    }

    public async Task<string> GetApplicationLogoUrl()
    {
        if (string.IsNullOrEmpty(_ApplicationOptions.Value.LogoUrl))
        {
            string searchKey = "Application:LogoUrl";
            return await GetSystemsSettingsAsync(searchKey);
        }
        else return _ApplicationOptions.Value.LogoUrl;
    }

    public async Task<string> GetApplicationCopyright()
    {
        if (string.IsNullOrEmpty(_ApplicationOptions.Value.Copyright))
        {
            string searchKey = "Application:Copyright";
            return await GetSystemsSettingsAsync(searchKey);
        }
        else return _ApplicationOptions.Value.Copyright;
    }

    public async Task<string> GetApplicationCopyrightUrl()
    {
        if (string.IsNullOrEmpty(_ApplicationOptions.Value.CopyrightUrl))
        {
            string searchKey = "Application:CopyrightUrl";
            return await GetSystemsSettingsAsync(searchKey);
        }
        else return _ApplicationOptions.Value.CopyrightUrl;
    }

    private async Task<string> GetSystemsSettingsAsync(string searchKey)
    {
        var result = await _StorageContext.SystemsSettings.FirstOrDefaultAsync(s => s.Id == searchKey);
        return result!.Value;
    }
}
