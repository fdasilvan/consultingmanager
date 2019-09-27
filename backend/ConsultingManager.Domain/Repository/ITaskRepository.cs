using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConsultingManager.Dto;

namespace ConsultingManager.Domain.Repository
{
    public interface ITaskRepository
    {
        Task<CustomerTaskDto> FinishTask(Guid taskId);
        Task<List<CustomerTaskDto>> GetUserTasks(Guid userId);
        Task<CustomerTaskDto> GetTask(Guid taskId);
        Task<CustomerTaskDto> RescheduleTask(Guid taskId, DateTime newDate);
        Task<CustomerTaskDto> AnticipateTask(Guid taskId);
        Task<CustomerTaskDto> TransferTask(Guid taskId, Guid consultantId);
        Task<CustomerTaskDto> ReopenTask(Guid taskId);
    }
}