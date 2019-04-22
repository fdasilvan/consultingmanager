using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultingManager.Infra.Database.Models
{
    public class TaskTemplatePoco
    {
        public Guid Id { get; set; }

        public Guid StepId { get; set; }
        [ForeignKey(nameof(StepId))]
        public StepPoco Step { get; set; }

        public string Description { get; set; }
        public long Duration { get; set; }

    }
}
