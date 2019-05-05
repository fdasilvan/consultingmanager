using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultingManager.Infra.Database.Models
{
    public class CustomerStepPoco
    {
        public Guid Id { get; set; }

        public Guid ProcessId { get; set; }
        [ForeignKey(nameof(ProcessId))]
        public ModelProcessPoco Process { get; set; }

        public Guid StepId { get; set; }
        [ForeignKey(nameof(StepId))]
        public ModelStepPoco Step { get; set; }

        public Guid CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public CustomerPoco Customer { get; set; }
    }
}
