using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultingManager.Infra.Database.Models
{
    public class CustomerTaskPoco
    {
        public Guid Id { get; set; }

        public string Description { get; set; }
        public string Instructions { get; set; }
        public int Duration { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EstimatedEndDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string MailSubject { get; set; }
        public string MailBody { get; set; }

        public Guid CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public CustomerPoco Customer { get; set; }

        public Guid CustomerUserId { get; set; }
        [ForeignKey(nameof(CustomerUserId))]
        public UserPoco CustomerUser { get; set; }

        public Guid ConsultantId { get; set; }
        [ForeignKey(nameof(ConsultantId))]
        public UserPoco Consultant { get; set; }

        public Guid OwnerId { get; set; }
        [ForeignKey(nameof(OwnerId))]
        public UserPoco Owner { get; set; }

        public Guid TaskTypeId { get; set; }
        [ForeignKey(nameof(TaskTypeId))]
        public TaskTypePoco TaskType { get; set; }

        public Guid ModelTaskId { get; set; }
        [ForeignKey(nameof(ModelTaskId))]
        public ModelTaskPoco ModelTask { get; set; }

        public Guid CustomerStepId { get; set; }
        [ForeignKey(nameof(CustomerStepId))]
        public CustomerStepPoco CustomerStep { get; set; }

        public virtual ICollection<CommentPoco> Comments { get; set; }
    }
}
