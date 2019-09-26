using System.Collections.Generic;
using System.Threading.Tasks;
using ConsultingManager.Dto;

namespace ConsultingManager.Domain.Repository
{
    public interface IDashboardRepository
    {
        Task<List<CustomerTaskDto>> GetConsultantsTasks();
    }
}