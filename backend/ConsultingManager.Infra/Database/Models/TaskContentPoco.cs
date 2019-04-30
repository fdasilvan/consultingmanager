using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultingManager.Infra.Database.Models
{
    public class TaskContentPoco
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
    }
}
