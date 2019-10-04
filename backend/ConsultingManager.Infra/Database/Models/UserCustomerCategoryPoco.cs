using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConsultingManager.Infra.Database.Models
{
    public class UserCustomerCategoryPoco
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public UserPoco User { get; set; }
        public Guid CustomerCategoryId { get; set; }
        public CustomerCategoryPoco CustomerCategory { get; set; }
    }
}
