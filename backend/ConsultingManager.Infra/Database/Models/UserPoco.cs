using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultingManager.Infra.Database.Models
{
    public class UserPoco
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConferenceRoomAddress { get; set; }
        public int? AvailableHoursMonth { get; set; }

        public Guid UserTypeId { get; set; }
        [ForeignKey(nameof(UserTypeId))]
        public UserTypePoco UserType { get; set; }

        public Guid? CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public CustomerPoco Customer { get; set; }

        public virtual ICollection<UserCustomerCategoryPoco> UserCustomerCategories { get; set; }
        public virtual ICollection<UserCustomerLevelPoco> UserCustomerLevels { get; set; }
    }
}
