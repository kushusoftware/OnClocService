#nullable disable

using System.ComponentModel.DataAnnotations;

namespace OnClocService.Core.Entities.Systems;

public class SystemsRefreshToken
{
    [Key]
    public Guid TokenID { get; set; } = Guid.NewGuid();
    public required string UserName { get; set; }
    public string Token { get; set; }
    public DateTimeOffset Created { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset? Revoked { get; set; }
    public DateTimeOffset Expiry { get; set; }
    public bool IsExpired => DateTimeOffset.UtcNow > Expiry;
    public bool IsActive => Revoked == null && !IsExpired;
}

public class SystemsAuthenticationTicket
{
    [Key]
    public Guid TicketID { get; set; }
    public required string UserId { get; set; }
    public string DeviceFamily { get; set; }
    public string DeviceModel { get; set; }
    public string OperatingSystemFamily { get; set; }
    public string OperatingSystemVersion { get; set; }
    public string UserAgentFamily { get; set; }
    public string UserAgentVersion { get; set; }
    public string RemoteIpAddress { get; set; }

    // Properties
    public byte[] Value { get; set; }
    public DateTimeOffset LastActivity { get; set; }
    public DateTimeOffset? Expires { get; set; }
    public bool IsExpired => Expires <= DateTime.UtcNow;
}

