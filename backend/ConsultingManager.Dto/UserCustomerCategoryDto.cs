using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultingManager.Dto
{
    public class UserCustomerCategoryDto
    {
        public Guid UserId { get; set; }
        public Guid CustomerCategoryId { get; set; }
        public CustomerCategoryDto CustomerCategory { get; set; }
    }
}
