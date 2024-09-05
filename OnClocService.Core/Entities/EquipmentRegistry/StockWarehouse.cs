#nullable disable

using OnClocService.Core.EntityBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnClocService.Core.Entities.EquipmentRegistry;

public class StockWarehouse : SystemsEntityBase
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int StockWarehouseID {  get; set; }

    // Properties
    public string StockWarehouseCode { get; set; }

    public string StockWarehouseName { get; set; }

    // Navigation
    public ICollection<StockProduct> StockProducts { get; set; }
}
