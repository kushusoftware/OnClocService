
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OnClocService.Domain.DataModels.Systems;
using OnClocService.Domain.Interfaces.Systems;
using OnClocService.Infrastructure.DataStorage;

namespace OnClocService.Infrastructure.Handlers.Systems;

internal class BusinessOptionsHandler(OnClocDataStorageContext storageContext, IOptions<SystemsBusinessOptions> businessOptions) : IBusinessOptionsService
{
    private readonly OnClocDataStorageContext _StorageContext = storageContext;
    private readonly IOptions<SystemsBusinessOptions> _BusinessOptions = businessOptions;

    public async Task<string> GetBusinessID()
    {
        if (string.IsNullOrEmpty(_BusinessOptions.Value.ID))
        {
            string searchKey = "Business:ID";
            return await GetSystemsSettingsAsync(searchKey);
        }
        return _BusinessOptions.Value.ID;
    }

    public async Task<string> GetBusinessFullName()
    {
        if (string.IsNullOrEmpty(_BusinessOptions.Value.FullName))
        {
            string searchKey = "Business:FullName";
            return await GetSystemsSettingsAsync(searchKey);
        }
        return _BusinessOptions.Value.FullName;
    }

    public async Task<string> GetBusinessShortName()
    {
        if (string.IsNullOrEmpty(_BusinessOptions.Value.ShortName))
        {
            string searchKey = "Business:ShortName";
            return await GetSystemsSettingsAsync(searchKey);
        }
        return _BusinessOptions.Value.ShortName;
    }

    public async Task<string> GetBusinessLogoUrl()
    {
        if (string.IsNullOrEmpty(_BusinessOptions.Value.LogoUrl))
        {
            string searchKey = "Business:LogoUrl";
            return await GetSystemsSettingsAsync(searchKey);
        }
        return _BusinessOptions.Value.LogoUrl;
    }

    private async Task<string> GetSystemsSettingsAsync(string searchKey)
    {
        var result = await _StorageContext.SystemsSettings.FirstOrDefaultAsync(s => s.Id == searchKey);
        return result!.Value;
    }
}
