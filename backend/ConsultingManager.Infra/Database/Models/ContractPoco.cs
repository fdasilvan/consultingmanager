using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultingManager.Infra.Database.Models
{
    public class ContractPoco
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Guid? CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public CustomerPoco Customer { get; set; }

        public Guid? PlanId { get; set; }
        [ForeignKey(nameof(PlanId))]
        public PlanPoco Plan { get; set; }

        public Guid? ContractSituationId { get; set; }
        [ForeignKey(nameof(ContractSituationId))]
        public ContractSituationPoco ContractSituation { get; set; }
    }
}
