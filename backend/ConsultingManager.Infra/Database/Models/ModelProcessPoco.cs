using System;
using System.Collections.Generic;

namespace ConsultingManager.Infra.Database.Models
{
    public class ModelProcessPoco
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ModelStepPoco> ModelSteps { get; set; }
        public bool Enabled { get; set; }
    }
}
