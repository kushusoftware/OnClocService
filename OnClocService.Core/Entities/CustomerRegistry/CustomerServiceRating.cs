#nullable disable

using OnClocService.Core.EntityBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnClocService.Core.Entities.CustomerRegistry;

public class CustomerServiceRating : SystemsEntityBase
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid CustomerServiceRatingID { get; set; }
    public int CustomerFeedbackQuestionId { get; set; }
    public Guid CustomerServiceTicketId { get; set; }

    // Properties
    public int RatingScore { get; set; }
    public string Comment { get; set; }

    // Tracking
    [ForeignKey(nameof(CustomerFeedbackQuestionId))]
    public CustomerFeedbackQuestion CustomerFeedbackQuestion { get; set; }

    [ForeignKey(nameof(CustomerServiceTicketId))]
    public CustomerServiceTicket CustomerServiceTicket { get; set; }
}
