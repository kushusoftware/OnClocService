

namespace OnClocService.Domain.Interfaces.Systems;

public interface ISupportOptionsService
{
    Task<string> GetSupportPhone();
    Task<string> GetSupportEmail();
    Task<string> GetSupportLearnUrl();
}
