using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultingManager.Dto
{
    public class StartCustomerProcessDto
    {
        public Guid ModelProcessId { get; set; }
        public string ModelProcessDescription { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ConsultantId { get; set; }
        public Guid CustomerUserId { get; set; }
        public DateTime StartDate { get; set; }
        public Guid? CustomerMeetingId { get; set; }
    }
}
