#nullable disable

using OnClocService.Core.EntityBase;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnClocService.Core.Entities.EquipmentRegistry;

public class EquipmentCategory : SystemsEntityBase
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int EquipmentCategoryID { get; set; }

    // Properties
    [StringLength(100)]
    public string CategoryCode { get; set; }
    public string CategorytName { get; set; }

    // Navigation
    public ICollection<StockProduct> StockProducts { get; set; }
    public ICollection<CustomerEquipment> CustomerEquipment { get; set; }
    public ICollection<EquipmentFamilyCategory> EquipmentFamilyCategories { get; set; }
    public ICollection<EquipmentCategoryGroup> EquipmentCategoryGroups { get; set; }
}

public class EquipmentCategoryGroup : SystemsEntityBase
{
    [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int EquipmentCategoryGroupID { get; set; }
    public int EquipmentCategoryId { get; set; }
    public int EquipmentGroupId { get; set; }

    // Tracking
    [ForeignKey(nameof(EquipmentCategoryId))]
    public EquipmentCategory EquipmentCategory { get; set; }

    [ForeignKey(nameof(EquipmentGroupId))]
    public EquipmentGroup EquipmentGroup { get; set; }
}
