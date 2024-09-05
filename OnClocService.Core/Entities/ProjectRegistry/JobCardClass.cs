#nullable disable

using OnClocService.Core.EntityBase;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using OnClocService.Core.Entities.TechnicianRegistry;

namespace OnClocService.Core.Entities.ProjectRegistry;

public class JobCardClass
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int JobCardClassID { get; set; }

    // Properties
    [StringLength(100)]
    public string Name { get; set; }
    public string Description { get; set; }
    public string ColourCode { get; set; }

    // Navigation
    public ICollection<JobCard> JobCards { get; set; }
    public ICollection<ServiceDeskPortfolio> ServiceDeskPortfolios { get; set; }
    public ICollection<JobCardCategoryClass> JobCardCategoryClasses { get; set; }
    public ICollection<JobCardClassGroup> JobCardClassGroups { get; set; }
}

public class JobCardClassGroup
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int JobCardClassGroupID { get; set; }
    public int JobCardClassId { get; set; }
    public int JobCardGroupId { get; set; }

    // Tracking
    [ForeignKey(nameof(JobCardClassId))]
    public JobCardClass JobCardClass {  get; set; }

    [ForeignKey(nameof(JobCardGroupId))]
    public JobCardGroup JobCardGroup { get; set; }
}