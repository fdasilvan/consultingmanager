using System;

namespace ConsultingManager.Dto
{
    public class CommentDto
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }

        public Guid UserId { get; set; }
        public UserDto User { get; set; }

        public Guid? CustomerMeetingId { get; set; }
        public CustomerMeetingDto CustomerMeeting { get; set; }

        public Guid? CustomerTaskId { get; set; }
        public CustomerTaskDto CustomerTask { get; set; }

        public Guid? CustomerId { get; set; }
        public CustomerDto Customer { get; set; }
    }
}
