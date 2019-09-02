using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConsultingManager.Dto;

namespace ConsultingManager.Domain.Repository
{
    public interface IProcessRepository
    {
        Task<List<ModelProcessDto>> GetAll();
        Task<bool> Save(ModelProcessDto modelProcessoDto);
        Task<bool> Delete(Guid customerProcessId);
        Task<CustomerProcessDto> StartCustomerProcess(ModelProcessDto modelProcessDto, Guid customerId, Guid consultantId, Guid customerUserId, DateTime startDate, string detail, Guid? customerMeetingId);
        Task<List<CustomerProcessDto>> GetCustomerTasks(Guid customerId);
    }
}