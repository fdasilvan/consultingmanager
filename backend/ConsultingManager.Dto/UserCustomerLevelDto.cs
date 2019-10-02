using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultingManager.Dto
{
    public class UserCustomerLevelDto
    {
        public Guid UserId { get; set; }
        public Guid CustomerLevelId { get; set; }
        public CustomerLevelDto CustomerLevel { get; set; }
    }
}
