#nullable disable

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnClocService.Core.Entities.ProjectRegistry
{
    public class JobCardStatus
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobCardStatusID { get; set; }

        // Properties
        [StringLength(100)]
        public string Status { get; set; }
        public string ColourCode { get; set; }

        // Navigation
        public ICollection<JobCard> JobCards { get; set; }
    }
}
