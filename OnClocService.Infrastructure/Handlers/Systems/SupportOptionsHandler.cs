

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OnClocService.Domain.DataModels.Systems;
using OnClocService.Domain.Interfaces.Systems;
using OnClocService.Infrastructure.DataStorage;

namespace OnClocService.Infrastructure.Handlers.Systems;

internal class SupportOptionsHandler(OnClocDataStorageContext storageContext, IOptions<SystemsSupportOptions> supportOptions) : ISupportOptionsService
{
    private readonly OnClocDataStorageContext _StorageContext = storageContext;
    private readonly IOptions<SystemsSupportOptions> _SupportOptions = supportOptions;

    public async Task<string> GetSupportPhone()
    {
        if (string.IsNullOrEmpty(_SupportOptions.Value.Phone))
        {
            string searchKey = "Support:Phone";
            return await GetSystemsSettingsAsync(searchKey);
        }
        return _SupportOptions.Value.Phone;
    }

    public async Task<string> GetSupportEmail()
    {
        if (string.IsNullOrEmpty(_SupportOptions.Value.Email))
        {
            string searchKey = "Support:Email";
            return await GetSystemsSettingsAsync(searchKey);
        }
        return _SupportOptions.Value.Email;
    }


    public async Task<string> GetSupportLearnUrl()
    {
        if (string.IsNullOrEmpty(_SupportOptions.Value.LearnUrl))
        {
            string searchKey = "Support:LearnUrl";
            return await GetSystemsSettingsAsync(searchKey);
        }
        return _SupportOptions.Value.LearnUrl;
    }

    private async Task<string> GetSystemsSettingsAsync(string searchKey)
    {
        var result = await _StorageContext.SystemsSettings.FirstOrDefaultAsync(s => s.Id == searchKey);
        return result!.Value;
    }
}
