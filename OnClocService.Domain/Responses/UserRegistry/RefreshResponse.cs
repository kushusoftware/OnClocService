#nullable disable

using OnClocService.Domain.Responses.Systems;
using System.Text.Json.Serialization;

namespace OnClocService.Domain.Responses.UserRegistry;

public class RefreshResponse : SystemsResponse
{
    [JsonIgnore]
    public string Token { get; set; }
    public DateTimeOffset Expiry { get; set; }
}
