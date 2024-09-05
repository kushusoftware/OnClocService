
namespace OnClocService.Domain.Interfaces.Systems;

public interface IEmailOptionsService
{
    Task<string> GetEmailFromAddress();
    Task<string> GetEmailFromName();
    Task<string> GetEmailUsername();
    Task<string> GetEmailPassword();
    Task<string> GetEmailHost();
    Task<int> GetEmailPort();
    Task<bool> GetEmailUseSsl();
}
