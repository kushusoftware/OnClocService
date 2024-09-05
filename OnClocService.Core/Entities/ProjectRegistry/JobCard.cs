#nullable disable

using OnClocService.Core.Entities.TaskRegistry;
using OnClocService.Core.Entities.TechnicianRegistry;
using OnClocService.Core.Entities.TicketRegistry;
using OnClocService.Core.Entities.TravelRegistry;
using OnClocService.Core.EntityBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnClocService.Core.Entities.ProjectRegistry
{
    public class JobCard : SystemsEntityBase
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid JobCardID { get; set; }
        public Guid ServiceTicketId { get; set; }
        public int ServiceProjectId { get; set; }
        public int JobCardStatusId { get; set; }
        public int JobCardPriorityLevelId { get; set; }
        public int JobCardTypeId { get; set; }
        public int JobCardCategoryId { get; set; }
        public int JobCardClassId { get; set; }
        public int JobCardGroupId { get; set; }
        public int JobCardGenreId { get; set; }

        // Properties
        public string Number { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime ScheduledDate {  get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan EstimatedDuration { get; set; }
        public TimeSpan ActualDuration { get; set; }
        public bool AllowReOpen { get; set; } = false;

        // Tracking
        [ForeignKey(nameof(ServiceTicketId))]
        public ServiceTicket ServiceTicket { get; set; }

        [ForeignKey(nameof(ServiceProjectId))]
        public ServiceProject ServiceProject { get; set; }

        [ForeignKey(nameof(JobCardStatusId))]
        public JobCardStatus JobCardStatus { get; set; }

        [ForeignKey(nameof(JobCardPriorityLevelId))]
        public JobCardPriorityLevel JobCardPriorityLevel { get; set; }

        [ForeignKey(nameof(JobCardTypeId))]
        public JobCardType JobCardType { get; set; }

        [ForeignKey(nameof(JobCardCategoryId))]
        public JobCardCategory JobCardCategory { get; set; }

        [ForeignKey(nameof(JobCardClassId))]
        public JobCardClass JobCardClass { get; set; }

        [ForeignKey(nameof(JobCardGroupId))]
        public JobCardGroup JobCardGroup { get; set; }

        [ForeignKey(nameof(JobCardGenreId))]
        public JobCardGenre JobCardGenre { get; set; }

        // Navigation
        public ICollection<JobCardAllocation> JobCardAllocations { get; set; }
        public ICollection<JobCardChecklist> JobCardChecklists { get; set; }
        public ICollection<JobTimeCard> JobTimeCards { get; set; }
    }
}
