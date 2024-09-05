#nullable disable

using OnClocService.Core.Entities.ProjectRegistry;
using OnClocService.Core.EntityBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnClocService.Core.Entities.TechnicianRegistry;

public class ServiceDesk : SystemsEntityBase
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ServiceDeskID { get; set; }
    
    // Properties
    public string ServiceDeskName { get; set; }
    public string ServiceDeskDescription { get; set; }

    // Navigation
    public ICollection<ServiceDeskMember> ServiceDeskMembers { get; set; }
    public ICollection<ServiceDeskPortfolio> ServiceDeskPortfolios { get; set; }
    public ICollection<ServiceDeskProjectAllocation>  ServiceDeskProjectAllocations { get; set; }
}

public class ServiceDeskProjectAllocation : SystemsEntityBase
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ServiceProjectDeskID { get; set; }
    public int ServiceDeskId { get; set; }
    public int ServiceProjectId { get; set; }

    // Tracking
    [ForeignKey(nameof(ServiceProjectId))]
    public ServiceProject ServiceProject { get; set; }

    [ForeignKey(nameof(ServiceDeskId))]
    public ServiceDesk ServiceDesk { get; set; }
}