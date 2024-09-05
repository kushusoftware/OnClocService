#nullable disable

using OnClocService.Core.Entities.ProjectRegistry;
using OnClocService.Core.Entities.TicketRegistry;
using OnClocService.Core.EntityBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnClocService.Core.Entities.TechnicianRegistry;

public class ServiceDeskPortfolio : SystemsEntityBase
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ServiceDeskProtfolioID { get; set; }
    public int ServiceDeskId { get; set; }
    public int ServiceTicketCategoryId { get; set; }
    public int JobCardTypeId { get; set; }
    public int JobCardCategoryId { get; set; }
    public int JobCardClassId { get; set; }
    public int JobCardGroupId { get; set; }
    public int JobCardGenreId { get; set; }

    // Properties
    public bool ManageServiceTicketCategory { get; set; }
    public bool ManageJobCardType { get; set; }
    public bool ManageJobCardCategory { get; set; }
    public bool ManageJobCardClass { get; set; }
    public bool ManageJobCardGroup { get; set; }
    public bool ManageJobCardGenre { get; set; }

    // Tracking
    [ForeignKey(nameof(ServiceDeskId))]
    public ServiceDesk ServiceDesk { get; set; }

    [ForeignKey(nameof(ServiceTicketCategoryId))]
    public ServiceTicketCategory ServiceTicketCategory { get; set; }

    [ForeignKey(nameof(JobCardTypeId))]
    public JobCardType JobCardType { get; set; }

    [ForeignKey(nameof(JobCardCategoryId))]
    public JobCardCategory JobCardCategory { get; set; }

    [ForeignKey(nameof(JobCardClassId))]
    public JobCardClass JobCardClass { get; set; }

    [ForeignKey(nameof(JobCardGroupId))]
    public JobCardGroup JobCardGroup { get; set; }

    [ForeignKey(nameof(JobCardGenreId))]
    public JobCardGenre JobCardGenre { get; set; }
}
