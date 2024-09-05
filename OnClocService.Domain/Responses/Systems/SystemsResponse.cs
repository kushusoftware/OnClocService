#nullable disable

using System.Text.Json.Serialization;

namespace OnClocService.Domain.Responses.Systems;

public abstract class SystemsResponse
{
    [JsonIgnore]
    public bool Success { get; set; } = false;
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ErrorCode { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Error { get; set; }
}
