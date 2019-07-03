using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultingManager.Infra.Database.Models
{
    public class CustomerPoco
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        public string StoreUrl { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public Guid? ConsultantId { get; set; }
        [ForeignKey(nameof(ConsultantId))]
        public UserPoco Consultant { get; set; }

        public Guid PlatformId { get; set; }
        [ForeignKey(nameof(PlatformId))]
        public PlatformPoco Platform { get; set; }

        public Guid? PlanId { get; set; }
        [ForeignKey(nameof(PlanId))]
        public PlanPoco Plan { get; set; }

        public Guid? CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public CustomerCategoryPoco Category { get; set; }

        public Guid? SituationId { get; set; }
        [ForeignKey(nameof(SituationId))]
        public CustomerSituationPoco Situation { get; set; }

        public Guid? CityId { get; set; }
        [ForeignKey(nameof(CityId))]
        public CityPoco City { get; set; }

        public virtual ICollection<CustomerProcessPoco> CustomerProcesses { get; set; }
        public virtual ICollection<UserPoco> Users { get; set; }
    }
}
