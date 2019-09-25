using System.Collections.Generic;
using System.Threading.Tasks;
using ConsultingManager.Dto;

namespace ConsultingManager.Domain.Repository
{
    public interface IDashboardRepository
    {
        Task<List<ChartResultDto>> GetConsultantsDueTasks();
        Task<List<ChartResultDto>> GetConsultantsOnTimeTasks();
        Task<List<ChartResultDto>> GetCustomersDueTasks();
        Task<List<ChartResultDto>> GetCustomersOnTimeTasks();
    }
}