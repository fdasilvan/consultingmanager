using System;
using System.Collections.Generic;

namespace ConsultingManager.Dto
{
    public class ModelProcessDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public ICollection<ModelStepDto> ModelSteps { get; set; }
    }
}
