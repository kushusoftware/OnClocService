#nullable disable

namespace OnClocService.Core.Entities.Systems;

/// <summary>
/// Systems configurtion LogSettings
/// </summary>
/// <param name="Id">configuration id</param>
/// <param name="Value">value of assigned configuration</param>
public record SystemsSettings(string Id, string Value);
