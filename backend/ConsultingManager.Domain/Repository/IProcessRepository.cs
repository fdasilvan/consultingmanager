using System;
using System.Threading.Tasks;
using ConsultingManager.Dto;

namespace ConsultingManager.Domain.Repository
{
    public interface IProcessRepository
    {
        Task<CustomerProcessDto> StartCustomerProcess(ModelProcessDto modelProcessDto, Guid customerId);
    }
}