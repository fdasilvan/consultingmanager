using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ConsultingManager.Infra.Database.Models
{
    public class CommentPoco
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }

        public Guid UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public UserPoco User { get; set; }

        public Guid? CustomerMeetingId { get; set; }
        [ForeignKey(nameof(CustomerMeetingId))]
        public CustomerMeetingPoco CustomerMeeting { get; set; }

        public Guid? CustomerTaskId { get; set; }
        [ForeignKey(nameof(CustomerTaskId))]
        public CustomerTaskPoco CustomerTask { get; set; }

        public Guid? CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public CustomerPoco Customer { get; set; }
    }
}
