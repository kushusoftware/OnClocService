#nullable disable

namespace OnClocService.Domain.DataModels.Systems;

public class PermissionSignature
{
    public string Policy { get; set; }
    public string Privilege { get; set; }
    public string Module { get; set; } = string.Empty;
    public string Page { get; set; } = string.Empty;
}
