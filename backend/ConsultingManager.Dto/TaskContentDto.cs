using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultingManager.Dto
{
    public class TaskContentDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string VideoUrl { get; set; }
        public int PageNumber { get; set; }
    }
}
