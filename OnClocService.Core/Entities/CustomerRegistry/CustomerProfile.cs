#nullable disable

using OnClocService.Core.Entities.EquipmentRegistry;
using OnClocService.Core.Entities.Systems;
using OnClocService.Core.EntityBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnClocService.Core.Entities.CustomerRegistry;

public class CustomerProfile : SystemsEntityBase
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid CustomerProfileID { get; set; }
    public Guid UserId { get; set; }
    public Guid SystemsContactDetailId { get; set; }

    // Properties
    public string CustomerName { get; set; }

    // Tracking
    [ForeignKey(nameof(SystemsContactDetailId))]
    public SystemsContactDetail SystemsContactDetail { get; set; }

    // Navigation
    public ICollection<CustomerServiceTicket> CustomerServiceTickets { get; set; }
    public ICollection<CustomerEquipment> CustomerEquipment { get; set; }
}