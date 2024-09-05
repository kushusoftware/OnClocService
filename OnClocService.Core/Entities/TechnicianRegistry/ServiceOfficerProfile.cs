#nullable disable

using OnClocService.Core.Entities.Systems;
using OnClocService.Core.Entities.TaskRegistry;
using OnClocService.Core.Entities.TicketRegistry;
using OnClocService.Core.Entities.TravelRegistry;
using OnClocService.Core.EntityBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnClocService.Core.Entities.TechnicianRegistry;

public class ServiceOfficerProfile : SystemsEntityBase
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid ServiceOfficerProfileID { get; set; }
    public Guid UserId { get; set; }
    public Guid SystemsContactDetailId { get; set; }
    public int ServiceOfficerDesignationId { get; set; }

    // Properties
    public int InputterLevel { get; set; } = 0;
    public int AuthorizerLevel { get; set; } = 0;

    // Tracking
    [ForeignKey(nameof(SystemsContactDetailId))]
    public SystemsContactDetail SystemsContactDetail { get; set; }

    [ForeignKey(nameof(ServiceOfficerDesignationId))]
    public ServiceOfficerDesignation ServiceOfficerDesignation { get; set; }

    // Navigation
    public ICollection<ServiceDeskMember> ServiceDeskMembers { get; set; }
    public ICollection<JobCardChecklistTask> JobCardChecklistTasks { get; set; }
    public ICollection<ServiceTicketTask> ServiceTicketTasks { get; set; }
    public ICollection<TravelPlanBooking> TravelPlanBookings { get; set; }
}

public class ServiceOfficerDesignation : SystemsEntityBase
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ServiceOfficerDesignationID { get; set; }

    // Properties
    public string DesignationTitle { get; set; }

    // Navigation
    public ICollection<ServiceOfficerProfile> ServiceOfficerProfiles { get; set; }
}
