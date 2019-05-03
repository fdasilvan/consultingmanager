using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultingManager.Infra.Database.Models
{
    public class UserPoco
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Guid UserTypeId { get; set; }
        [ForeignKey(nameof(UserTypeId))]
        public UserTypePoco UserType { get; set; }
    }
}
