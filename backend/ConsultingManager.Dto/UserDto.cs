using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultingManager.Dto
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConferenceRoomAddress { get; set; }
        public int AvailableHoursMonth { get; set; }

        public Guid UserTypeId { get; set; }
        public UserTypeDto UserType { get; set; }

        public Guid? CustomerId { get; set; }

        public virtual ICollection<CustomerCategoryDto> CustomerCategories { get; set; }
        public virtual ICollection<CustomerLevelDto> CustomerLevels { get; set; }
    }
}
