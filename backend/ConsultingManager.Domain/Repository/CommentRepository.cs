using ConsultingManager.Dto;
using ConsultingManager.Infra.Database;
using ConsultingManager.Infra.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tnf.EntityFrameworkCore;
using Tnf.EntityFrameworkCore.Repositories;
using Tnf.Repositories;

namespace ConsultingManager.Domain.Repository
{
    public class CommentRepository : EfCoreRepositoryBase<ConsultingManagerDbContext, CommentPoco>, IRepository<CommentPoco>, ICommentRepository
    {
        public CommentRepository(IDbContextProvider<ConsultingManagerDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<CommentDto> Add(CommentDto commentDto)
        {
            commentDto.User = null;
            commentDto.Date = DateTime.Now;

            var newComment = Context.Comments.Add(commentDto.MapTo<CommentPoco>());
            await Context.SaveChangesAsync();
            return newComment.Entity.MapTo<CommentDto>();
        }

        public async Task<List<CommentDto>> GetMeetingComments(Guid customerMeetingId)
        {
            return await Context.Comments
                .Include(comment => comment.Customer)
                .Include(comment => comment.User)
                .Include(comment => comment.CustomerMeeting)
                .Where(comment => comment.CustomerMeetingId == customerMeetingId)
                .Select(task => task.MapTo<CommentDto>())
                .ToListAsync();
        }

        public async Task<List<CommentDto>> GetCustomerComments(Guid customerId)
        {
            return await Context.Comments
                .Include(comment => comment.Customer)
                .Include(comment => comment.User)
                .Where(comment => comment.CustomerId == customerId)
                .Select(task => task.MapTo<CommentDto>())
                .ToListAsync();
        }
    }
}
