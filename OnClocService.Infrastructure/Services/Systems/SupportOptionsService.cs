

using OnClocService.Domain.Interfaces.Systems;

namespace OnClocService.Infrastructure.Services.Systems;

public class SupportOptionsService(ISupportOptionsService supportOptions)
{
    public async Task<string> GetPhone() => await supportOptions.GetSupportPhone();
    public async Task<string> GetEmail() => await supportOptions.GetSupportEmail();
    public async Task<string> GetLearnUrl() => await supportOptions.GetSupportLearnUrl();
}
