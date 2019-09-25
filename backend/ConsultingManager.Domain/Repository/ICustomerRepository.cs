using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConsultingManager.Dto;

namespace ConsultingManager.Domain.Repository
{
    public interface ICustomerRepository
    {
        Task<CustomerDto> Add(CustomerDto customerDto);
        Task<CustomerDto> Update(CustomerDto customerDto);
        Task<CustomerDto> Transfer(Guid customerId, Guid consultantId);
        Task<bool> AddMeetings(Guid customerId, List<CustomerMeetingDto> customerMeetings);
        Task<List<CustomerMeetingDto>> GetMeetings(Guid customerId);
        Task<List<CustomerDto>> GetAll();
        Task<CustomerDto> Get(Guid customerId);
        Task<List<CityDto>> GetCities();
        Task<List<CustomerCategoryDto>> GetCustomerCategories();
        Task<List<CustomerSituationDto>> GetCustomerSituations();
        Task<List<CustomerLevelDto>> GetCustomerLevels();
        Task<List<PlanDto>> GetPlans();
        Task<List<PlatformDto>> GetPlatforms();
        Task<List<UserDto>> GetConsultants();
    }
}