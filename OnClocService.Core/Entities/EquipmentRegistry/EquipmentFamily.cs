#nullable disable

using OnClocService.Core.EntityBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnClocService.Core.Entities.EquipmentRegistry;

public class EquipmentFamily : SystemsEntityBase
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int EquipmentFamilyID { get; set; }

    // Properties
    [StringLength(100)]
    public string FamilyCode { get; set; }
    public string FamilyName { get; set; }

    // Navigation
    public ICollection<StockProduct> StockProducts { get; set; }
    public ICollection<CustomerEquipment> CustomerEquipment { get; set; }
    public ICollection<EquipmentFamilyCategory> EquipmentFamilyCategories { get; set; }
}

public class EquipmentFamilyCategory : SystemsEntityBase
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int EquipmentFamilyCategoryID { get; set; }
    public int EquipmentFamilyId { get; set; }
    public int EquipmentCategoryId { get; set; }

    // Tracking
    [ForeignKey(nameof(EquipmentFamilyId))]
    public EquipmentFamily EquipmentFamily { get; set; }

    [ForeignKey(nameof(EquipmentCategoryId))]
    public EquipmentCategory EquipmentCategory { get; set; }
}