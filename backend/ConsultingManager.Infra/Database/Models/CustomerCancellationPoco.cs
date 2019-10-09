using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultingManager.Infra.Database.Models
{
    public class CustomerCancellationPoco
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }

        public Guid CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public CustomerPoco Customer { get; set; }

        public Guid CancellationReasonId { get; set; }
        [ForeignKey(nameof(CancellationReasonId))]
        public CancellationReasonPoco CancellationReason { get; set; }

        public Guid UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public UserPoco User { get; set; }
    }
}
