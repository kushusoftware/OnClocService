#nullable disable

using OnClocService.Core.EntityBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnClocService.Core.Entities.EquipmentRegistry;

public class StockProduct : SystemsEntityBase
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid StockProductID { get; set; }
    public int StockWarehouseId { get; set; }
    public int EquipmentBrandId { get; set; }
    public int EquipmentFamilyId { get; set; }
    public int EquipmentCategoryId { get; set; }
    public int EquipmentGroupId { get; set; }

    // Properties
    public string ProductCode { get; set; }
    public string ProductName { get; set; }
    public string ProductDescription { get; set; }
    public string ProductModel { get; set; }
    public string ProductPartNumber {  get; set; }
    public string ProductSerialNumber { get; set; }
    public double InventoryCount { get; set; }
    public double AveragePrice { get; set; }

    // Tracking
    [ForeignKey(nameof(StockWarehouseId))]
    public StockWarehouse StockWarehouse { get; set; }

    [ForeignKey(nameof(EquipmentBrandId))]
    public EquipmentBrand ProductBrand { get; set; }

    [ForeignKey(nameof(EquipmentFamilyId))]
    public EquipmentFamily EquipmentFamily { get; set; }

    [ForeignKey(nameof(EquipmentCategoryId))]
    public EquipmentCategory EquipmentCategory { get; set; }

    [ForeignKey(nameof(EquipmentGroupId))]
    public EquipmentGroup ProductGroup { get; set; }

}
