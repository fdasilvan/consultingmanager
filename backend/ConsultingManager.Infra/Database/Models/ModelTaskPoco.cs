using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultingManager.Infra.Database.Models
{
    public class ModelTaskPoco
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Instructions { get; set; }
        public int Duration { get; set; }
        public int StartAfterDays { get; set; }
        public int DueDays { get; set; }

        public Guid TaskTypeId { get; set; }
        [ForeignKey(nameof(TaskTypeId))]
        public TaskTypePoco TaskType{ get; set; }

        public Guid CustomerStepId { get; set; }
        [ForeignKey(nameof(CustomerStepId))]
        public CustomerStepPoco CustomerStep { get; set; }
    }
}
