using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConsultingManager.Infra.Database.Models
{
    public class UserCustomerLevelPoco
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public UserPoco User { get; set; }
        public Guid CustomerLevelId { get; set; }
        public CustomerLevelPoco CustomerLevel { get; set; }
    }
}
