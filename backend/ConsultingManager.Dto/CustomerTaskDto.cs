using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultingManager.Dto
{
    public class CustomerTaskDto
    {
        public Guid Id { get; set; }

        public string Description { get; set; }
        public string Instructions { get; set; }
        public int Duration { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EstimatedEndDate { get; set; }
        public DateTime? EndDate { get; set; }

        public Guid CustomerId { get; set; }
        public CustomerDto Customer { get; set; }

        public Guid CustomerUserId { get; set; }
        public UserDto CustomerUser { get; set; }

        public Guid ConsultantId { get; set; }
        public UserDto Consultant { get; set; }

        public Guid OwnerId { get; set; }
        public UserDto Owner { get; set; }

        public Guid TaskTypeId { get; set; }
        public TaskTypeDto TaskType { get; set; }

        public Guid ModelTaskId { get; set; }
        public ModelTaskDto ModelTask { get; set; }

        public CustomerStepDto CustomerStep { get; set; }
    }
}
