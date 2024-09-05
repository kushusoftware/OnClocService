
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OnClocService.Domain.DataModels.Systems;
using OnClocService.Domain.Interfaces.Systems;
using OnClocService.Infrastructure.DataStorage;

namespace OnClocService.Infrastructure.Handlers.Systems;

internal class JwtOptionsHandler(OnClocDataStorageContext storageContext, IOptions<SystemsJwtOptions> jwtOptionsAccessor) : IJwtOptionsService
{
    private readonly OnClocDataStorageContext _StorageContext = storageContext;
    private readonly IOptions<SystemsJwtOptions> _JwtOptions = jwtOptionsAccessor;

    public async Task<string> GetJwtKey()
    {
        if (string.IsNullOrEmpty(_JwtOptions.Value.Key))
        {
            string searchKey = "Jwt:Key";
            return await GetSystemsSettingsAsync(searchKey);
        }
        else return _JwtOptions.Value.Key;
    }

    public async Task<string> GetJwtIssuer()
    {
        if (string.IsNullOrEmpty(_JwtOptions.Value.Issuer))
        {
            string searchKey = "Jwt:Issuer";
            return await GetSystemsSettingsAsync(searchKey);
        }
        else return _JwtOptions.Value.Issuer;
    }

    public async Task<string> GetJwtAudience()
    {
        if (string.IsNullOrEmpty(_JwtOptions.Value.Audience))
        {
            string searchKey = "Jwt:Audience";
            return await GetSystemsSettingsAsync(searchKey);
        }
        else return _JwtOptions.Value.Audience;
    }

    public async Task<int> GetJwtDurationMinutes()
    {
        string duration = _JwtOptions.Value.DurationMinutes;
        if (string.IsNullOrEmpty(_JwtOptions.Value.DurationMinutes))
        {
            string searchKey = "Jwt:DurationMinutes";
            duration = await GetSystemsSettingsAsync(searchKey);
        }
        return int.Parse(duration);
    }

    private async Task<string> GetSystemsSettingsAsync(string searchKey)
    {
        var result = await _StorageContext.SystemsSettings.FirstOrDefaultAsync(s => s.Id == searchKey);
        return result!.Value;
    }
}
