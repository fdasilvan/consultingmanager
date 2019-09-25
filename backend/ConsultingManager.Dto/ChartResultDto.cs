using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultingManager.Dto
{
    public class ChartResultDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
    }
}
