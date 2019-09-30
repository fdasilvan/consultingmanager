using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultingManager.Infra.Database.Models
{
    public class UserCustomerLevelPoco
    {
        public Guid UserId { get; set; }
        public UserPoco User { get; set; }
        public Guid CustomerLevelId { get; set; }
        public CustomerLevelPoco CustomerLevel { get; set; }
    }
}
