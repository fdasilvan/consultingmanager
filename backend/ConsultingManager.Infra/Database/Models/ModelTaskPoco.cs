using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultingManager.Infra.Database.Models
{
    public class ModelTaskPoco
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Instructions { get; set; }
        public long Duration { get; set; }
        public long StartAfterDays { get; set; }
        public long DueDays { get; set; }

        public Guid TaskTypeId { get; set; }
        [ForeignKey(nameof(TaskTypeId))]
        public TaskTypePoco TaskType{ get; set; }

        public Guid StepId { get; set; }
        [ForeignKey(nameof(StepId))]
        public CustomerStepPoco Step { get; set; }
    }
}
