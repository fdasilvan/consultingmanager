using ConsultingManager.Dto;
using ConsultingManager.Infra;
using ConsultingManager.Infra.Database;
using ConsultingManager.Infra.Database.Models;
using Microsoft.AspNetCore.Mvc;
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
    public class TaskRepository : EfCoreRepositoryBase<ConsultingManagerDbContext, ModelTaskPoco>, IRepository<ModelTaskPoco>, ITaskRepository
    {
        public TaskRepository(IDbContextProvider<ConsultingManagerDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<CustomerTaskDto>> GetUserTasks(Guid userId)
        {
            return await Context.CustomerTasks
                .Include(task => task.Owner)
                .Include(task => task.Customer)
                .Include(task => task.Consultant)
                .Include(task => task.Customer)
                .Include(task => task.CustomerUser)
                .Include(task => task.TaskType)
                .Include(task => task.ModelTask).ThenInclude(modelTask => modelTask.TaskContent)
                .Where(task => task.OwnerId == userId && task.EndDate == null && task.StartDate < DateTime.Now)
                .Select(task => task.MapTo<CustomerTaskDto>())
                .ToListAsync();
        }

        public async Task<CustomerTaskDto> FinishTask(Guid taskId)
        {
            CustomerTaskPoco task = await Context.CustomerTasks
                .Where(o => o.Id == taskId)
                .FirstOrDefaultAsync();

            task.EndDate = DateTime.Now;
            await Context.SaveChangesAsync();
            return task.MapTo<CustomerTaskDto>();
        }

        public async Task<CustomerTaskDto> ReopenTask(Guid taskId)
        {
            CustomerTaskPoco task = await Context.CustomerTasks
                .Where(o => o.Id == taskId)
                .FirstOrDefaultAsync();

            task.EndDate = null;
            await Context.SaveChangesAsync();
            return task.MapTo<CustomerTaskDto>();
        }

        public async Task<CustomerTaskDto> RescheduleTask(Guid taskId, DateTime newDate)
        {
            CustomerTaskPoco task = await Context.CustomerTasks
                .Where(o => o.Id == taskId)
                .FirstOrDefaultAsync();

            task.EstimatedEndDate = newDate;
            await Context.SaveChangesAsync();
            return task.MapTo<CustomerTaskDto>();
        }
    }
}
