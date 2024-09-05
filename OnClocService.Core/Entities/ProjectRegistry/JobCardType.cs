#nullable disable

using OnClocService.Core.Entities.TechnicianRegistry;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnClocService.Core.Entities.ProjectRegistry;

public class JobCardType
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int JobCardTypeID { get; set; }

    // Properties
    [StringLength(100)]
    public string Name { get; set; }
    public string Description { get; set; }
    public string ColourCode { get; set; }

    // Navigation
    public ICollection<JobCard> JobCards { get; set; }
    public ICollection<ServiceDeskPortfolio> ServiceDeskPortfolios { get; set; }
    public ICollection<JobCardTypeCategory> JobCardTypeCategories { get; set; }
}

public class JobCardTypeCategory
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int JobCardTypeCategoryID { get; set; }
    public int JobCardTypeId { get; set; }
    public int JobCardCategoryId { get; set; }

    // Tracking
    [ForeignKey(nameof(JobCardTypeId))]
    public JobCardType JobCardType { get; set; }

    [ForeignKey(nameof(JobCardCategoryId))]
    public JobCardCategory JobCardCategory { get; set; }
}
