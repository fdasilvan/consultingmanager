using System;

namespace ConsultingManager.Infra.Database.Models
{
    public class PlanPoco
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
    }
}
