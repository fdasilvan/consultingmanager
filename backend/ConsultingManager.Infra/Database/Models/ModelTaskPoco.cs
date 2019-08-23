using System;
using System.Collections.Generic;
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
        public string MailSubject { get; set; }
        public string MailBody { get; set; }

        public Guid TaskTypeId { get; set; }
        [ForeignKey(nameof(TaskTypeId))]
        public TaskTypePoco TaskType { get; set; }

        public Guid ModelStepId { get; set; }
        [ForeignKey(nameof(ModelStepId))]
        public ModelStepPoco ModelStep { get; set; }

        public virtual ICollection<TaskContentPoco> TaskContent { get; set; }
    }
}
