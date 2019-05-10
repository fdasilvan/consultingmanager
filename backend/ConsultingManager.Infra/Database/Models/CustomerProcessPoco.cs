using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultingManager.Infra.Database.Models
{
    public class CustomerProcessPoco
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EstimatedEndDate { get; set; }
        public DateTime? EndDate { get; set; }

        public Guid ModelProcessId { get; set; }
        [ForeignKey(nameof(ModelProcessId))]
        public ModelProcessPoco ModelProcess { get; set; }

        public Guid CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public CustomerPoco Customer { get; set; }

        public virtual ICollection<CustomerStepPoco> CustomerSteps { get; set; }
    }
}
