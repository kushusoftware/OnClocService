

using OnClocService.Domain.Interfaces.Systems;

namespace OnClocService.Infrastructure.Services.Systems;

internal class EmailOptionsService(IEmailOptionsService emailOptions)
{
    public async Task<string> GetFromAddress() => await emailOptions.GetEmailFromAddress();
    public async Task<string> GetFromName() => await emailOptions.GetEmailFromName();
    public async Task<string> GetUsername() => await emailOptions.GetEmailUsername();
    public async Task<string> GetPassword() => await emailOptions.GetEmailPassword();
    public async Task<string> GetHost() => await emailOptions.GetEmailHost();
    public async Task<int> GetPort() => await emailOptions.GetEmailPort();
    public async Task<bool> GetUseSsl() => await emailOptions.GetEmailUseSsl();
}
