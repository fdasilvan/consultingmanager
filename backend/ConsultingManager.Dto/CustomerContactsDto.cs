using System;

namespace ConsultingManager.Dto
{
    public class CustomerContactDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }

        public Guid CustomerId { get; set; }
        public CustomerDto Customer { get; set; }
    }
}
