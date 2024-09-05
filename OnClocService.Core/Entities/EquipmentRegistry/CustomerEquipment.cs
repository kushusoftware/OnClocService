#nullable disable

using OnClocService.Core.Entities.CustomerRegistry;
using OnClocService.Core.EntityBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnClocService.Core.Entities.EquipmentRegistry;

public class CustomerEquipment : SystemsEntityBase
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid CustomerEquipmentID { get; set; }
    public Guid CustomerProfileId { get; set; }
    public int EquipmentBrandId { get; set; }
    public int EquipmentFamilyId { get; set; }
    public int EquipmentCategoryId { get; set; }
    public int EquipmentGroupId { get; set; }

    // Properties
    public string EquipmentCode { get; set; }
    public string EquipmentName { get; set; }
    public string EquipmentDescription { get; set; }
    public string EquipmentModel { get; set; }
    public string EquipmentPartNumber { get; set; }
    public string EquipmentSerialNumber { get; set; }
    public double EquipmentCount { get; set; }
    public string WarrantyTerms { get; set; }

    // Tracking
    [ForeignKey(nameof(CustomerProfileId))]
    public CustomerProfile CustomerProfile { get; set; }

    [ForeignKey(nameof(EquipmentBrandId))]
    public EquipmentBrand EquipmentBrand { get; set; }

    [ForeignKey(nameof(EquipmentFamilyId))]
    public EquipmentFamily EquipmentFamily { get; set; }

    [ForeignKey(nameof(EquipmentCategoryId))]
    public EquipmentCategory EquipmentCategory { get; set; }

    [ForeignKey(nameof(EquipmentGroupId))]
    public EquipmentGroup EquipmentGroup { get; set; }
}
