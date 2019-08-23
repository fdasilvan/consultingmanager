using System;
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
        public string MailSubject { get; set; }
        public string MailBody { get; set; }

        public Guid ModelStepId { get; set; }

        public Guid TaskTypeId { get; set; }
        public TaskTypeDto TaskType { get; set; }

        public ICollection<TaskContentDto> TaskContent { get; set; }
    }
}
