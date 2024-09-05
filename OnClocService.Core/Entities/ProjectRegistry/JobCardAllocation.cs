#nullable disable

using OnClocService.Core.EntityBase;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using OnClocService.Core.Entities.TechnicianRegistry;
using OnClocService.Core.Entities.TaskRegistry;

namespace OnClocService.Core.Entities.ProjectRegistry;

public class JobCardAllocation : SystemsEntityBase
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid JobCardAllocationID { get; set; }
    public Guid JobCardId { get; set; }
    public Guid ServiceDeskMemberId { get; set; }

    // Properties
    public TimeSpan ServiceLevelDuration { get; set; }
    public DateTime AssignOnDate { get; set; } = DateTime.MinValue;
    public DateTime DueOnDate => DateTime.UtcNow.Add(ServiceLevelDuration);
    public bool IsAssigned => AssignOnDate != DateTime.MinValue;
    public bool IsPrimaryTechnician { get; set; }

    // Tracking
    [ForeignKey(nameof(JobCardId))]
    public JobCard JobCard { get; set; }

    [ForeignKey(nameof(ServiceDeskMemberId))]
    public ServiceDeskMember ServiceDeskMember { get; set; }
}