#nullable disable

using System.ComponentModel.DataAnnotations;

namespace OnClocService.Domain.Requests.UserRegistry;

public class LoginRequest
{
    [EmailAddress]
    public string Email { get; set; }

    [DataType(DataType.Password)]
    public string Password { get; set; }

    public bool RememberMe { get; set; }
}
