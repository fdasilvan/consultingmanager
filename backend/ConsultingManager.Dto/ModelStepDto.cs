using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultingManager.Dto
{
    public class ModelStepDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }

        public Guid ProcessId { get; set; }
        public ModelProcessDto Process { get; set; }
    }
}
