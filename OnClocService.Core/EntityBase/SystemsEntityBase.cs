#nullable disable

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnClocService.Core.EntityBase
{
    public class SystemsEntityBase
    {
        [Display(Name = "Date Created"), DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Date Modified"), DataType(DataType.DateTime)]
        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;

        [Display(Name = "Created By"), StringLength(100, ErrorMessage = "created by username greater than allowed string length")]
        public required string CreatedBy { get; set; }

        [Display(Name = "Modified By"), StringLength(100, ErrorMessage = "modified by username greater than allowed string length")]
        public required string ModifiedBy { get; set; }

        [Display(Name = "Enabled"), DefaultValue(true)]
        public bool IsEnabled { get; set; }

        [Timestamp]
        public byte[] ConcurrencyToken { get; set; }
    }
}
