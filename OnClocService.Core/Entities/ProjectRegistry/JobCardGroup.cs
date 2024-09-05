#nullable disable

using OnClocService.Core.EntityBase;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using OnClocService.Core.Entities.TechnicianRegistry;

namespace OnClocService.Core.Entities.ProjectRegistry;

public class JobCardGroup
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int JobCardGroupID { get; set; }

    // Properties
    [StringLength(100)]
    public string Name { get; set; }
    public string Description { get; set; }
    public string ColourCode { get; set; }

    // Navigation
    public ICollection<JobCard> JobCards { get; set; }
    public ICollection<ServiceDeskPortfolio> ServiceDeskPortfolios { get; set; }
    public ICollection<JobCardClassGroup> JobCardClassGroups { get; set; }
    public ICollection<JobCardGroupGenre> JobCardGroupGenres { get; set; }
}

public class JobCardGroupGenre
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int JobCardGroupGenreID { get; set; }
    public int JobCardGroupId { get; set; }
    public int JobCardGenreId { get; set; }

    // Tracking
    [ForeignKey(nameof(JobCardGroupId))]
    public JobCardGroup JobCardGroup { get; set; }

    [ForeignKey(nameof(JobCardGenreId))]
    public JobCardGenre JobCardGenre { get; set; }
}