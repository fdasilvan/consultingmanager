using System;

namespace ConsultingManager.Dto
{
    public class CustomerCancellationDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }
        public Guid CustomerId { get; set; }
        public CustomerDto Customer { get; set; }

        public Guid CancellationReasonId { get; set; }
        public CancellationReasonDto CancellationReason { get; set; }

        public Guid UserId { get; set; }
        public UserDto User { get; set; }
    }
}
