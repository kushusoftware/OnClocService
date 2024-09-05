#nullable disable

using OnClocService.Core.EntityBase;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using OnClocService.Core.Entities.TicketRegistry;
using OnClocService.Core.Entities.ProjectRegistry;

namespace OnClocService.Core.Entities.TechnicianRegistry;

public class ServiceDeskMember : SystemsEntityBase
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid ServiceDeskMemberID { get; set; }
    public int ServiceDeskId { get; set; }
    public Guid ServiceOfficerProfileId { get; set; }

    // Tracking
    [ForeignKey(nameof(ServiceOfficerProfileId))]
    public ServiceOfficerProfile ServiceOfficerProfile { get; set; }

    [ForeignKey(nameof(ServiceDeskId))]
    public ServiceDesk ServiceDesk { get; set; }

    // Navigation
    public ICollection<ServiceTicketAllocation> ServiceTicketAllocations { get; set; }
    public ICollection<JobCardAllocation> JobCardAllocations { get; set; }
}