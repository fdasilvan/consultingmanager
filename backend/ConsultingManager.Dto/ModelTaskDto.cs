﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultingManager.Dto
{
    public class ModelTaskDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Instructions { get; set; }
        public int Duration { get; set; }
        public int StartAfterDays { get; set; }
        public int DueDays { get; set; }

        public Guid TaskTypeId { get; set; }
        public TaskTypeDto TaskType { get; set; }

        public ICollection<TaskContentDto> TaskContent { get; set; }
    }
}
