using System;

namespace ConsultingManager.Infra.Database.Models
{
    public class ProcessPoco
    {
        public Guid Id { get; set; }
        public string Descritpion { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EstimatedEndDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
