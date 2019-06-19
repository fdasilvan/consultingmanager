using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultingManager.Infra.Database.Models
{
    public class TaskContentPoco
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string VideoUrl { get; set; }
        public int PageNumber { get; set; }

        public Guid ModelTaskId { get; set; }
        [ForeignKey(nameof(ModelTaskId))]
        public ModelTaskPoco ModelTask { get; set; }
    }
}
