#nullable disable

using OnClocService.Core.EntityBase;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using OnClocService.Core.Entities.TechnicianRegistry;

namespace OnClocService.Core.Entities.ProjectRegistry;

public class JobCardCategory
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int JobCardCategoryID { get; set; }

    // Properties
    [StringLength(100)]
    public string Name { get; set; }
    public string Description { get; set; }
    public string ColourCode { get; set; }

    // Navigation
    public ICollection<JobCard> JobCards { get; set; }
    public ICollection<ServiceDeskPortfolio> ServiceDeskPortfolios { get; set; }
    public ICollection<JobCardTypeCategory> JobCardTypeCategories { get; set; }
    public ICollection<JobCardCategoryClass> JobCardCategoryClasses { get; set; }
}

public class JobCardCategoryClass
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int JobCardCategoryClassID { get; set; }
    public int JobCardCategoryId { get; set; }
    public int JobCardClassId { get; set; }

    // Tracking
    [ForeignKey(nameof(JobCardCategoryId))]
    public JobCardCategory JobCardCategory { get; set; }

    [ForeignKey(nameof(JobCardClassId))]
    public JobCardClass JobCardClass { get; set; }
}
