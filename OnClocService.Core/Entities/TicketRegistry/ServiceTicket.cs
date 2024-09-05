#nullable disable

using OnClocService.Core.Entities.CustomerRegistry;
using OnClocService.Core.Entities.ProjectRegistry;
using OnClocService.Core.EntityBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnClocService.Core.Entities.TicketRegistry;

public class ServiceTicket : SystemsEntityBase
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid ServiceTicketID { get; set; }
    public int ServiceTicketStatusId { get; set; }
    public int ServiceTicketPriorityLevelId { get; set; }
    public int ServiceTicketCategoryId { get; set; }

    // Properties
    public string Subject { get; set; }
    public string Description { get; set; }
    public string Remarks { get; set; }
    public DateTime OpenedOnDate { get; set; }
    public DateTime ClosedOnDate { get; set; }
    public TimeSpan TicketAge { get; set; }
    public bool AllowTransition { get; set; } = true;

    // Tracking
    [ForeignKey(nameof(ServiceTicketStatusId))]
    public ServiceTicketStatus ServiceTicketStatus { get; set; }

    [ForeignKey(nameof(ServiceTicketPriorityLevelId))]
    public ServiceTicketPriorityLevel ServiceTicketPriorityLevel { get; set; }

    [ForeignKey(nameof(ServiceTicketCategoryId))]
    public ServiceTicketCategory ServiceTicketCategory { get; set; }

    // Navigation
    public ICollection<CustomerServiceTicket> CustomerServiceTickets { get; set; }
    public ICollection<ServiceTicketTask> ServiceTicketTasks { get; set; }
    public ICollection<ServiceTicketAllocation> ServiceTicketAllocations { get; set; }
    public ICollection<ServiceTicketAttachment> ServiceTicketAttachments { get; set; }
    public ICollection<JobCard> JobCards { get; set; }
}

public class ServiceTicketAttachment : SystemsEntityBase
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid ServiceTicketAttachmentID { get; set; }
    public Guid ServiceTicketId { get; set; }

    // Properties
    public string Name { get; set; }
    public string AttachmentUrl { get; set; }

    // Tracking
    [ForeignKey(nameof(ServiceTicketId))]
    public ServiceTicket ServiceTicket { get; set; }
}
