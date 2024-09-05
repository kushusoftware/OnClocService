

using OnClocService.Domain.Interfaces.Systems;

namespace OnClocService.Infrastructure.Services.Systems;

public class LicenseOptionsService(ILicenseOptionsService licenseOptions)
{
    public async Task<string> GetName() => await licenseOptions.GetLicenseName();
    public async Task<DateTime> GetActive() => await licenseOptions.GetLicenseActive();
    public async Task<DateTime> GetExpiry() => await licenseOptions.GetLicenseExpiry();
    public async Task<string> GetKey() => await licenseOptions.GetLicenseKey();
}
