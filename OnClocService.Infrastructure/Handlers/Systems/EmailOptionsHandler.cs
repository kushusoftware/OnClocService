

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OnClocService.Domain.DataModels.Systems;
using OnClocService.Domain.Interfaces.Systems;
using OnClocService.Infrastructure.DataStorage;

namespace OnClocService.Infrastructure.Handlers.Systems;

internal class EmailOptionsHandler(OnClocDataStorageContext storageContext, IOptions<SystemsEmailOptions> emailOptionsAccessor) : IEmailOptionsService
{
    private readonly OnClocDataStorageContext _StorageContext = storageContext;
    private readonly IOptions<SystemsEmailOptions> _EmailOptions = emailOptionsAccessor;

    public async Task<string> GetEmailFromAddress()
    {
        if (string.IsNullOrEmpty(_EmailOptions.Value.FromAddress))
        {
            string searchKey = "Email:FromAddress";
            return await GetSystemsSettingsAsync(searchKey);
        }
        else return _EmailOptions.Value.FromAddress;
    }

    public async Task<string> GetEmailFromName()
    {
        if (string.IsNullOrEmpty(_EmailOptions.Value.FromName))
        {
            string searchKey = "Email:FromName";
            return await GetSystemsSettingsAsync(searchKey);
        }
        else return _EmailOptions.Value.FromName;
    }

    public async Task<string> GetEmailUsername()
    {
        if (string.IsNullOrEmpty(_EmailOptions.Value.Username))
        {
            string searchKey = "Email:Username";
            return await GetSystemsSettingsAsync(searchKey);
        }
        else return _EmailOptions.Value.Username;
    }

    public async Task<string> GetEmailPassword()
    {
        if (string.IsNullOrEmpty(_EmailOptions.Value.Password))
        {
            string searchKey = "Email:Password";
            return await GetSystemsSettingsAsync(searchKey);
        }
        else return _EmailOptions.Value.Password;
    }

    public async Task<string> GetEmailHost()
    {
        if (string.IsNullOrEmpty(_EmailOptions.Value.Host))
        {
            string searchKey = "Email:Host";
            return await GetSystemsSettingsAsync(searchKey);
        }
        else return _EmailOptions.Value.Host;
    }


    public async Task<int> GetEmailPort()
    {
        if (string.IsNullOrEmpty(_EmailOptions.Value.Port))
        {
            string searchKey = "Email:Port";
            return int.Parse(await GetSystemsSettingsAsync(searchKey));
        }
        else return int.Parse(_EmailOptions.Value.Port);
    }

    public async Task<bool> GetEmailUseSsl()
    {
        if (string.IsNullOrEmpty(_EmailOptions.Value.UseSsl))
        {
            string searchKey = "Email:UseSsl";
            return bool.Parse(await GetSystemsSettingsAsync(searchKey));
        }
        else return bool.Parse(_EmailOptions.Value.UseSsl);
    }

    private async Task<string> GetSystemsSettingsAsync(string searchKey)
    {
        var result = await _StorageContext.SystemsSettings.FirstOrDefaultAsync(s => s.Id == searchKey);
        return result!.Value;
    }
}
