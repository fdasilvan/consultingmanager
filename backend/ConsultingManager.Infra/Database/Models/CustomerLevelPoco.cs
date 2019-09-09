using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ConsultingManager.Infra.Database.Models
{
    [Table("CustomerLevels")]
    public class CustomerLevelPoco
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public decimal RevenueLowLimit { get; set; }
        public decimal RevenueHighLimit { get; set; }
    }
}
