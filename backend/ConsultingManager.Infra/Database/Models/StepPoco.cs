using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultingManager.Infra.Database.Models
{
    public class StepPoco
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Guid ProcessId { get; set; }
        [ForeignKey(nameof(ProcessId))]
        public ProcessPoco Process { get; set; }
    }
}
