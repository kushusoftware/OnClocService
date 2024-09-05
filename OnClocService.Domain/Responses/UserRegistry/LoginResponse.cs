#nullable disable

using OnClocService.Domain.Responses.Systems;

namespace OnClocService.Domain.Responses.UserRegistry;

public class LoginResponse : SystemsResponse
{
    public string Message { get; set; }
    public bool LockedOut { get; set; } = false;
    public bool Requires2FA { get; set; } = false;
    public SecurityCredentials SecurityCredentials { get; set; }
}

public class SecurityCredentials
{
    public string TicketKey { get; set; }
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}