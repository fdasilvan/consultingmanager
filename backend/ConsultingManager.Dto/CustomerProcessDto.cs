using System;

namespace ConsultingManager.Dto
{
    public class CustomerProcessDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EstimatedEndDate { get; set; }
        public DateTime EndDate { get; set; }

        public Guid ModelProcessId { get; set; }
    }
}
