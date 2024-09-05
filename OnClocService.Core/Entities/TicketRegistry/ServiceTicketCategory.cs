#nullable disable

using OnClocService.Core.Entities.TechnicianRegistry;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnClocService.Core.Entities.TicketRegistry;

public class ServiceTicketCategory
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ServiceTicketCategoryID { get; set; }

    // Properties
    public string CategoryName { get; set; }
    public string CategoryDescription { get; set; }
    public string ColourCode { get; set; }


    // Navigation
    public ICollection<ServiceTicket> ServiceTickets { get; set; }
    public ICollection<ServiceDeskPortfolio> ServiceDeskPortfolios { get; set; }
}
