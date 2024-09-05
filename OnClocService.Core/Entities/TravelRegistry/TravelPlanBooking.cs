#nullable disable

using OnClocService.Core.Entities.TechnicianRegistry;
using OnClocService.Core.EntityBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnClocService.Core.Entities.TravelRegistry;

public class TravelPlanBooking : SystemsEntityBase
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid TravelPlanBookingID { get; set; }
    public Guid TravelPlanId { get; set; }
    public Guid ServiceOfficerProfileId { get; set; }

      // Properties
    public DateTime BookingDate { get; set; }
    public DateTime? DeferredDate { get; set; }
    public bool IsApproved { get; set; }
    public bool IsDeferred { get; set; }

    // Tracking
    [ForeignKey(nameof(TravelPlanId))]
    public TravelPlan TravelPlan { get; set; }

    [ForeignKey(nameof(ServiceOfficerProfileId))]
    public ServiceOfficerProfile ServiceOfficerProfile { get; set; }

    // Navigation
    public ICollection<TravelItenerary> TravelIteneraries { get; set; }

}
