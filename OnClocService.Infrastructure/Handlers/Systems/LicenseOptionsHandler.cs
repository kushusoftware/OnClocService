

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OnClocService.Domain.DataModels.Systems;
using OnClocService.Domain.Interfaces.Systems;
using OnClocService.Infrastructure.DataStorage;

namespace OnClocService.Infrastructure.Handlers.Systems;

internal class LicenseOptionsHandler(OnClocDataStorageContext storageContext, IOptions<SystemsLicenseOptions> licenseOptions) : ILicenseOptionsService
{
    private readonly OnClocDataStorageContext _StorageContext = storageContext;
    private readonly IOptions<SystemsLicenseOptions> _LicenseOptions = licenseOptions;

    public async Task<string> GetLicenseName()
    {
        if (string.IsNullOrEmpty(_LicenseOptions.Value.Name))
        {
            string searchKey = "License:Name";
            return await GetSystemsSettingsAsync(searchKey);
        }
        return _LicenseOptions.Value.Name;
    }

    public async Task<DateTime> GetLicenseActive()
    {
        if (string.IsNullOrEmpty(_LicenseOptions.Value.Active))
        {
            string searchKey = "License:Active";
            return DateTime.Parse(await GetSystemsSettingsAsync(searchKey));
        }
        return DateTime.Parse(_LicenseOptions.Value.Active);
    }

    public async Task<DateTime> GetLicenseExpiry()
    {
        if (string.IsNullOrEmpty(_LicenseOptions.Value.Expiry))
        {
            string searchKey = "License:Expiry";
            return DateTime.Parse(await GetSystemsSettingsAsync(searchKey));
        }
        return DateTime.Parse(_LicenseOptions.Value.Expiry);
    }

    public async Task<string> GetLicenseKey()
    {
        if (string.IsNullOrEmpty(_LicenseOptions.Value.Key))
        {
            string searchKey = "License:Key";
            return await GetSystemsSettingsAsync(searchKey);
        }
        return _LicenseOptions.Value.Key;
    }

    private async Task<string> GetSystemsSettingsAsync(string searchKey)
    {
        var result = await _StorageContext.SystemsSettings.FirstOrDefaultAsync(s => s.Id == searchKey);
        return result!.Value;
    }
}
