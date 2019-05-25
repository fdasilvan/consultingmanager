using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultingManager.Dto
{
    public class StartCustomerProcessDto
    {
        public Guid modelProcessId { get; set; }
        public string modelProcessDescription { get; set; }
        public Guid customerId { get; set; }
        public Guid consultantId { get; set; }
        public Guid customerUserId { get; set; }
        public DateTime startDate { get; set; }
    }
}
