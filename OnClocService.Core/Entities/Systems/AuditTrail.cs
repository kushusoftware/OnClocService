#nullable disable

using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OnClocService.Core.Constants;
using OnClocService.Core.Entities.UserRegistry;

namespace OnClocService.Core.Entities.Systems;

public record SystemsActivityLog
{
    [Key]
    public Guid SystemsActivityLogID { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; }

    // Properties
    public DateTime TimeStampUtc { get; set; } = DateTime.UtcNow;
    public LogLevel LogLevel { get; set; }
    public ActivityStatus ActivityStatus { get; set; }

    // Tracking
    [ForeignKey(nameof(UserId))] 
    public SystemsUser SystemsUser { get; set; }

    // Navigation
    public ICollection<SystemsAuditEvent> SystemsAuditEvents { get; set; }
}


public class SystemsAuditEvent
{
    [Key]
    public Guid SystemsAuditEventID { get; set; }
    public Guid SystemsActivityLogId { get; set; }
    [StringLength(10)]
    public string SystemsModuleId { get; set; }
    [StringLength(10)]
    public string SystemsPageId { get; set; }

    // Properties
    public string EventDescription { get; set; }

    // Tracking
    [ForeignKey(nameof(SystemsActivityLogId))] 
    public SystemsActivityLog SystemsActivityLog { get; set; }

    [ForeignKey(nameof(SystemsModuleId))] 
    public SystemsModule SystemsModule { get; set; }

    [ForeignKey(nameof(SystemsPageId))] 
    public SystemsPage SystemsPage { get; set; }

    // Navigation
    public ICollection<SystemsChangeLog> SystemsChangeLogs { get; set; }
}

public record SystemsChangeLog
{
    [Key]
    public Guid SystemsChangeLogID { get; set; }
    public Guid SystemsAuditEventId { get; set; }

    // Properties
    public ChangeStatus ChangeStatus { get; set; }
    public required string Description { get; set; }
    public required string OriginalValue { get; set; }
    public required string ChangedToValue { get; set; }

    // Tracking
    [ForeignKey(nameof(SystemsAuditEventId))] 
    public SystemsAuditEvent SystemsAuditEvent { get; set; }
}
