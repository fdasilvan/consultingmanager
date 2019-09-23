using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultingManager.Infra.Database.Models
{
    public class ModelStepPoco
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid ProcessId { get; set; }
        [ForeignKey(nameof(ProcessId))]
        public ModelProcessPoco Process { get; set; }
        public virtual ICollection<ModelTaskPoco> ModelTasks { get; set; }
        public bool Enabled { get; set; }
    }
}
