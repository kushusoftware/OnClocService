#nullable disable

namespace OnClocService.Domain.Requests.UserRegistry;

public class RefreshRequest
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}