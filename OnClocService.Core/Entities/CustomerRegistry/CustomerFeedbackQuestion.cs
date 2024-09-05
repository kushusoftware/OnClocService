#nullable disable

using OnClocService.Core.EntityBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnClocService.Core.Entities.CustomerRegistry;

public class CustomerFeedbackQuestion : SystemsEntityBase
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CustomerFeedbackQuestionID { get; set; }

    // Properties
    public string FeedbackQuestion { get; set; }
    public string FeedbackDescription { get; set; }

    // Navigation
    public ICollection<CustomerServiceRating> CustomerServiceRatings { get; set; }
}
