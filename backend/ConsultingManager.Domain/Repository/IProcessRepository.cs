using ConsultingManager.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsultingManager.Domain.Repository
{
    public interface IProcessRepository
    {
        Task<List<ModelProcessDto>> GetAll();
        Task<ModelProcessDto> Get(Guid modelProcessId);
        Task<bool> Save(ModelProcessDto modelProcessoDto);
        Task<bool> Delete(Guid customerProcessId);
        Task<ModelStepDto> DisableModelStep(Guid modelStepId);
        Task<CustomerProcessDto> StartCustomerProcess(ModelProcessDto modelProcessDto, Guid customerId, Guid consultantId, Guid customerUserId, DateTime startDate, string detail, Guid? customerMeetingId);
        Task<List<CustomerProcessDto>> GetCustomerTasks(Guid customerId, Guid? contractId);
        Task<bool> FinishStep(Guid customerStepId);
    }
}