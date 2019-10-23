using System;

namespace ConsultingManager.Infra.Database.Models
{
    public class PlanPoco
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public string MeetingsDescription { get; set; }
        public int ImplantationQuantity { get; set; }
        public int ImplantationFrequency { get; set; }
        public int ConsultingQuantity { get; set; }
        public int ConsultingFrequency { get; set; }
        public int ReviewQuantity { get; set; }
        public int ReviewFrequency { get; set; }
        public bool AllowGroupMeeting { get; set; }
    }
}
