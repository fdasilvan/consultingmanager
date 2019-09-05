using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConsultingManager.Dto;

namespace ConsultingManager.Domain.Repository
{
    public interface ICommentRepository
    {
        Task<CommentDto> Add(CommentDto commentDto);
        Task<List<CommentDto>> GetMeetingComments(Guid customerMeetingId);
        Task<List<CommentDto>> GetCustomerComments(Guid customerMeetingId);
        Task<List<CommentDto>> GetTaskComments(Guid customerTaskId);
    }
}