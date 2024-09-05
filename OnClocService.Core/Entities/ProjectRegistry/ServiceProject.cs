#nullable disable

using OnClocService.Core.Entities.TechnicianRegistry;
using OnClocService.Core.EntityBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnClocService.Core.Entities.ProjectRegistry;

public class ServiceProject : SystemsEntityBase
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ServiceProjectID { get; set; }

    // Propeties
    public string ServiceProjectName { get; set; }
    public string ServiceProjectDescription { get; set; }

    // Navigation
    public ICollection<JobCard> JobCards { get; set; }
    public ICollection<ServiceDeskProjectAllocation> ServiceDeskProjectAllocations { get; set; }
}
