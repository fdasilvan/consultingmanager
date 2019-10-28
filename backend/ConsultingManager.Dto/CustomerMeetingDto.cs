using System;
using System.Collections.Generic;

namespace ConsultingManager.Dto
{
    public class CustomerMeetingDto
    {
        public Guid Id { get; set; }
        public DateTime OriginalDate { get; set; }
        public DateTime Date { get; set; }
        public bool IsFinished { get; set; }

        public Guid CustomerId { get; set; }
        public CustomerDto Customer { get; set; }

        public Guid? ContractId { get; set; }
        public ContractDto Contract { get; set; }

        public Guid MeetingTypeId { get; set; }
        public MeetingTypeDto MeetingType { get; set; }
    }
}
