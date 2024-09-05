#nullable disable

using OnClocService.Core.EntityBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnClocService.Core.Entities.TravelRegistry;

public class TravelEvent : SystemsEntityBase
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TravelEventID { get; set; }

    // Properties
    public string TravelEventName { get; set; }
    public string TravelEventDescription {  get; set; }

    // Navigation
    public ICollection<TravelItenerary> TravelIteneraries { get; set; }
}
