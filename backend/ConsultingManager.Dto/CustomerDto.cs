using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultingManager.Dto
{
    public class CustomerDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        public string StoreUrl { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public Guid? ConsultantId { get; set; }
        public UserDto Consultant { get; set; }

        public Guid PlatformId { get; set; }
        public PlatformDto Platform { get; set; }

        public Guid? PlanId { get; set; }
        public PlanDto Plan { get; set; }

        public Guid? CategoryId { get; set; }
        public CustomerCategoryDto Category { get; set; }

        public Guid? SituationId { get; set; }
        public CustomerSituationDto Situation { get; set; }

        public Guid? CityId { get; set; }
        public CityDto City { get; set; }

        public ICollection<UserDto> Users { get; set; }
    }
}
