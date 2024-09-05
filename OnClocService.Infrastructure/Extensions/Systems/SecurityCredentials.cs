
using Microsoft.AspNetCore.Builder;
using OnClocService.Domain.Middleware;

namespace OnClocService.Infrastructure.Extensions.Systems;

public static class SecurityCredentials
{
    public static IApplicationBuilder UseSecurityCredentials(this IApplicationBuilder app)
    {
        return app.UseMiddleware<SecurityCredentialsMiddleware>();
    }
}
