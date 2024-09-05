
namespace OnClocService.Domain.Interfaces.Systems;

public interface ILicenseOptionsService
{
    Task<string> GetLicenseName();
    Task<DateTime> GetLicenseActive();
    Task<DateTime> GetLicenseExpiry();
    Task<string> GetLicenseKey();
}
