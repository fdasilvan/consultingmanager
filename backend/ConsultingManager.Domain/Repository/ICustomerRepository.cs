using System.Collections.Generic;
using System.Threading.Tasks;
using ConsultingManager.Dto;

namespace ConsultingManager.Domain.Repository
{
    public interface ICustomerRepository
    {
        Task<CustomerDto> Add(CustomerDto customerDto);
        Task<List<CustomerDto>> GetAll();
        Task<List<ChartResultDto>> GetChartResult();
        Task<List<CityDto>> GetCities();
        Task<List<CustomerCategoryDto>> GetCustomerCategories();
        Task<List<CustomerSituationDto>> GetCustomerSituations();
        Task<List<PlanDto>> GetPlans();
        Task<List<PlatformDto>> GetPlatforms();
    }
}