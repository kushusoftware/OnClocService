#nullable disable

using OnClocService.Core.EntityBase;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using OnClocService.Core.Entities.TechnicianRegistry;

namespace OnClocService.Core.Entities.ProjectRegistry;


public class JobCardGenre
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int JobCardGenreID { get; set; }

    // Properties
    [StringLength(100)]
    public string Name { get; set; }
    public string Description { get; set; }
    public string ColourCode { get; set; }

    //Navigation
    public ICollection<JobCard> JobCards { get; set; }
    public ICollection<ServiceDeskPortfolio> ServiceDeskPortfolios { get; set; }
    public ICollection<JobCardGroupGenre> JobCardGroupGenres { get; set; }
}