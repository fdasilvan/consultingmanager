using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultingManager.Dto
{
    public class CustomerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid PlatformId { get; set; }
        public PlatformDto Platform { get; set; }

        public string LogoUrl { get; set; }
    }
}
