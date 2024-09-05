#nullable disable

using OnClocService.Core.EntityBase;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnClocService.Core.Entities.TravelRegistry;

public class TravelPlan : SystemsEntityBase
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid TravelPlanID { get; set; }

    // Properties
    public string TravelPlanSubject { get; set; }
    public string TravelPlanDestination { get; set; }
    public string TravelPlanDescription { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    // Navigation
    public ICollection<TravelPlanBooking> TravelPlanBooking { get; set; }
}
