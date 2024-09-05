

using OnClocService.Domain.Interfaces.Systems;

namespace OnClocService.Infrastructure.Services.Systems;

public class BusinessOptionsService(IBusinessOptionsService businessOptions)
{
    public async Task<string> GetID() => await businessOptions.GetBusinessID();
    public async Task<string> GetFullName() => await businessOptions.GetBusinessFullName();
    public async Task<string> GetShortName() => await businessOptions.GetBusinessShortName();
    public async Task<string> GetLogoUrl() => await businessOptions.GetBusinessLogoUrl();
}
