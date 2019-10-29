using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultingManager.Infra.Database.Models
{
    public class CustomerMeetingPoco
    {
        public Guid Id { get; set; }

        public DateTime OriginalDate { get; set; }
        public DateTime Date { get; set; }
        public bool IsFinished { get; set; }

        public Guid CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public CustomerPoco Customer { get; set; }

        public Guid? ContractId { get; set; }
        [ForeignKey(nameof(ContractId))]
        public ContractPoco Contract { get; set; }

        public Guid? MeetingTypeId { get; set; }
        [ForeignKey(nameof(MeetingTypeId))]
        public MeetingTypePoco MeetingType { get; set; }

        public virtual ICollection<CustomerProcessPoco> CustomerProcesses { get; set; }
        public virtual ICollection<CommentPoco> Comments { get; set; }
    }
}
