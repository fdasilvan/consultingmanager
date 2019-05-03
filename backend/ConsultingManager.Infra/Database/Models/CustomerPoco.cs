using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultingManager.Infra.Database.Models
{
    public class CustomerPoco
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid PlatformId { get; set; }
        [ForeignKey(nameof(PlatformId))]
        public PlatformPoco Platform { get; set; }

        public string LogoUrl { get; set; }
    }
}
