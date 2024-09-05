#nullable disable

using OnClocService.Core.EntityBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnClocService.Core.Entities.TravelRegistry;

public class TravelItenerary : SystemsEntityBase
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid TravelIteneraryID { get; set; }
    public int TravelEventId { get; set; }
    public Guid TravelPlanBookingId { get; set; }

    // Properties
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Latitude {  get; set; }
    public string Longitude { get; set; }
    public double LatitudeAccuracy { get; set; }
    public double LongitudeAccuracy { get; set; }
    public string Comment { get; set; }

    // Tracking
    [ForeignKey(nameof(TravelEventId))]
    public TravelEvent TravelEvent { get; set; }

    [ForeignKey(nameof(TravelPlanBookingId))]
    public TravelPlanBooking TravelPlanBooking { get; set; }

    // Navigation
    public ICollection<JobTimeCard> JobTimeCards { get; set; }
}
