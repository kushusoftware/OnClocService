#nullable disable

using OnClocService.Core.EntityBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnClocService.Core.Entities.EquipmentRegistry;

public class EquipmentBrand : SystemsEntityBase
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int EquipmentBrandID { get; set; }
    public int EquipmentManufacturerId { get; set; }

    // Properties
    [StringLength(100)]
    public string BrandCode { get; set; }
    public string BrandName { get; set; }

    // Tracking
    [ForeignKey(nameof(EquipmentManufacturerId))]
    public EquipmentManufacturer EquipmentManufacturer { get; set; }

    // Navigation
    public ICollection<StockProduct> StockProducts { get; set; }
    public ICollection<CustomerEquipment> CustomerEquipment { get; set; }
}

public class EquipmentManufacturer : SystemsEntityBase
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int EquipmentManufacturerID { get; set; }

    public string EquipmentManufacturerName { get; set; }

    // Navigation
    public ICollection<EquipmentBrand> EquipmentBrands { get; set; }
}
