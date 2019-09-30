using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultingManager.Infra.Database.Models
{
    public class CustomerCategoryPoco
    {
        public Guid Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<UserCustomerCategoryPoco> UserCustomerCategories { get; set; }
    }
}
