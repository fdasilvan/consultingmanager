using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultingManager.Dto
{
    public class UserCustomerCategoryDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CustomerCategoryId { get; set; }
    }
}
