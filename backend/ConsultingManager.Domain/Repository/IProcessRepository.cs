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
        Task<CustomerProcessDto> StartCustomerProcess(ModelProcessDto modelProcessDto, Guid customerId, Guid consultantId, Guid customerUserId, DateTime startDate);
        Task<List<CustomerProcessDto>> GetCustomerTasks(Guid customerId);
    }
}