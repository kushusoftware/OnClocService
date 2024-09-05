

namespace OnClocService.Domain.Interfaces.Systems;

public interface IJwtOptionsService
{
    Task<string> GetJwtKey();
    Task<string> GetJwtIssuer();
    Task<string> GetJwtAudience();
    Task<int> GetJwtDurationMinutes();
}
