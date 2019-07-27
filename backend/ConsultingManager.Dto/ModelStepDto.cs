using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultingManager.Dto
{
    public class ModelStepDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public ICollection<ModelTaskDto> ModelTasks { get; set; }
    }
}
