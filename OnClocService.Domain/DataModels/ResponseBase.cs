#nullable disable

using System.Text.Json.Serialization;

namespace OnClocService.Domain.DataModels
{
    public abstract class ResponseBase
    {
        [JsonIgnore()]
        public bool Success { get; set; } = false;
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string ErrorCode { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string ErrorMessage { get; set; }
    }
}
