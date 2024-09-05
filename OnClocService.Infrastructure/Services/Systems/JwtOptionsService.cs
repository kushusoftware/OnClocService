using OnClocService.Domain.Interfaces.Systems;

namespace OnClocService.Infrastructure.Services.Systems;

public class JwtOptionsService(IJwtOptionsService jwtOptions)
{
    public async Task<string> GetKey() => await jwtOptions.GetJwtKey();
    public async Task<string> GetIssuer() => await jwtOptions.GetJwtIssuer();
    public async Task<string> GetAudience() => await jwtOptions.GetJwtAudience();
    public async Task<int> GetDurationMinutes() => await jwtOptions.GetJwtDurationMinutes();
}
