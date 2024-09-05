
namespace OnClocService.Domain.Interfaces.Systems;

public interface IBusinessOptionsService
{
    Task<string> GetBusinessID();
    Task<string> GetBusinessFullName();
    Task<string> GetBusinessShortName();
    Task<string> GetBusinessLogoUrl();
}
