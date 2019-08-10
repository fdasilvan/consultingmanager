using System;
using System.Collections.Generic;

namespace ConsultingManager.Dto
{
    public class CustomerMeetingDto
    {
        public Guid Id { get; set; }
        public DateTime OriginalDate { get; set; }
        public DateTime Date { get; set; }
        public Guid CustomerId { get; set; }
        public CustomerDto Customer { get; set; }
    }
}
