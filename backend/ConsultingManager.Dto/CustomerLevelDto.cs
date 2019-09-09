using System;

namespace ConsultingManager.Dto
{
    public class CustomerLevelDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public decimal RevenueLowLimit { get; set; }
        public decimal RevenueHighLimit { get; set; }
    }
}
