using System;

namespace ConsultingManager.Dto
{
    public class ContractDto
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Guid? CustomerId { get; set; }
        public CustomerDto Customer { get; set; }

        public Guid? PlanId { get; set; }
        public PlanDto Plan { get; set; }

        public Guid? ContractSituationId { get; set; }
        public ContractSituationDto ContractSituation { get; set; }
    }
}
