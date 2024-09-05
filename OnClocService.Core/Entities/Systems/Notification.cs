#nullable disable

using OnClocService.Core.Entities.UserRegistry;
using OnClocService.Core.EntityBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnClocService.Core.Entities.Systems;

public class SystemsNotification : SystemsEntityBase
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid SystemsNotificationID { get; set; }
    public int SystemsNotificationTypeId { get; set; }

    // Properties
    public string Subject { get; set; }
    public string Message { get; set; }
    public string Expiration {  get; set; }
    public string LinkToAction { get; set; }
    public bool SentSuccessfully { get; set; } = false;

    // Tracking
    [ForeignKey(nameof(SystemsNotificationTypeId))]
    public SystemsNotificationType SystemsNotificationType { get; set; }

    // Navigation
    public ICollection<SystemsUserNotification> SystemsUserNotifications { get; set; }
}

public class SystemsNotificationType : SystemsEntityBase
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SystemsNotificationTypeID { get; set; }

    // Properties
    public string NotificationType { get; set; }
    public int PriorityLevel { get; set; }

    // Navigation
    public ICollection<SystemsNotification> SystemsNotifications { get; set; }
}

public class SystemsUserNotification : SystemsEntityBase
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid SystemsUserNotificationID { get; set; }
    public Guid SystemsNotificationId { get; set; }
    public Guid UserId { get; set; }

    // Tracking
    [ForeignKey(nameof(SystemsNotificationId))]
    public SystemsNotification SystemsNotification {  get; set; }

    [ForeignKey(nameof(UserId))]
    public SystemsUser SystemsUser { get; set; }
}