using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultingManager.Infra.Database.Models
{
    public class ModelTaskContentPoco
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }

        public Guid ModelTaskId { get; set; }
        [ForeignKey(nameof(ModelTaskId))]
        public ModelTaskPoco ModelTask { get; set; }
    }
}
