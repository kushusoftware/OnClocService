#nullable disable

using OnClocService.Core.Entities.ProjectRegistry;
using OnClocService.Core.EntityBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnClocService.Core.Entities.TravelRegistry;

public class JobTimeCard : SystemsEntityBase
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid JobTimeCardID { get; set; }
    public Guid TravelIteneraryId { get; set; }
    public Guid JobCardId { get; set; }

    // Properties
    public TimeSpan TravelIteneraryDuration { get; set; }
    public string ApprovedBy { get; set; }
    public bool ISApproved { get; set; }

    // Tracking
    [ForeignKey(nameof(TravelIteneraryId))]
    public TravelItenerary TravelItenerary { get; set; }

    [ForeignKey(nameof(JobCardId))]
    public JobCard JobCard { get; set; }
}
