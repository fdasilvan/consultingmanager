﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultingManager.Dto
{
    public class PlanDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
    }
}
