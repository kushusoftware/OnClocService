#nullable disable

using OnClocService.Core.EntityBase;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnClocService.Core.Entities.EquipmentRegistry;

public class EquipmentGroup : SystemsEntityBase
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int EquipmentGroupID { get; set; }

    // Properties
    [StringLength(100)]
    public string GroupCode { get; set; }
    public string GroupName { get; set; }

    // Navigation
    public ICollection<StockProduct> StockProducts { get; set; }
    public ICollection<CustomerEquipment> CustomerEquipment { get; set; }
    public ICollection<EquipmentCategoryGroup> EquipmentCategoryGroups { get; set; }
}