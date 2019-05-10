using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultingManager.Infra.Database.Models
{
    public class CustomerStepPoco
    {
        public Guid Id { get; set; }

        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EstimatedEndDate { get; set; }
        public DateTime? EndDate { get; set; }

        public Guid CustomerProcessId { get; set; }
        [ForeignKey(nameof(CustomerProcessId))]
        public CustomerProcessPoco CustomerProcess { get; set; }

        public Guid ModelStepId { get; set; }
        [ForeignKey(nameof(ModelStepId))]
        public ModelStepPoco ModelStep { get; set; }

        public virtual ICollection<CustomerTaskPoco> CustomerTasks { get; set; }
    }
}
