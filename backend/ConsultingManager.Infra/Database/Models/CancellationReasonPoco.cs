using System;

namespace ConsultingManager.Infra.Database.Models
{
    public class CancellationReasonPoco
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
    }
}
