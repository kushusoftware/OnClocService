

using Microsoft.AspNetCore.Http;

namespace OnClocService.Domain.Middleware;

public class SecurityCredentialsMiddleware(RequestDelegate requestDelegate)
{
    private readonly RequestDelegate _RequestDelegate = requestDelegate;
    public static readonly object AccessToken = new();
    public static readonly object RefreshToken = new();

    public async Task Invoke(HttpContext context)
    {
        context.Items[AccessToken] = nameof(AccessToken);
        context.Items[RefreshToken] = nameof(RefreshToken);
        await _RequestDelegate(context);
    }
}
