using System;
using System.Collections.Generic;

namespace ConsultingManager.Dto
{
    public class CustomerStepDto
    {
        public Guid Id { get; set; }

        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EstimatedEndDate { get; set; }
        public DateTime? EndDate { get; set; }

        public Guid CustomerProcessId { get; set; }

        public Guid ModelStepId { get; set; }
        public ModelStepDto ModelStep { get; set; }

        public ICollection<CustomerTaskDto> CustomerTasks { get; set; }
    }
}
