using ConsultingManager.Dto;
using ConsultingManager.Infra;
using ConsultingManager.Infra.Database;
using ConsultingManager.Infra.Database.Models;
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
    public class CustomerRepository : EfCoreRepositoryBase<ConsultingManagerDbContext, CustomerPoco>, IRepository<CustomerPoco>, ICustomerRepository
    {
        public CustomerRepository(IDbContextProvider<ConsultingManagerDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<CustomerDto> Add(CustomerDto customerDto)
        {
            var newCustomer = Context.Customers.Add(customerDto.MapTo<CustomerPoco>());
            //await Context.SaveChangesAsync();
            return newCustomer.Entity.MapTo<CustomerDto>();
        }

        public async Task<List<CustomerDto>> GetAll()
        {
            return await Context.Customers
                .Include(o => o.Platform)
                .Include(o => o.Plan)
                .Include(o => o.Situation)
                .Include(o => o.Category)
                .Include(o => o.City)
                .Include(o => o.Users)
                    .ThenInclude(o => o.UserType)
                .OrderBy(o => o.Name)
                .Select(o => o.MapTo<CustomerDto>())
                .ToListAsync();
        }

        public async Task<List<ChartResultDto>> GetChartResult()
        {
            return await Context.CustomerTasks
                .Where(o => o.EndDate == null && o.EstimatedEndDate < DateTime.Now.AddDays(1))
                .GroupBy(p => new { p.Customer.Id, p.Customer.Name })
                .Select(g => new ChartResultDto { Description = g.Key.Name, Value = g.Count() })
                .ToListAsync();
        }

        public async Task<List<CityDto>> GetCities()
        {
            return await Context.Cities
                .Select(o => o.MapTo<CityDto>())
                .OrderBy(o => o.Name)
                .ToListAsync();
        }

        public async Task<List<PlatformDto>> GetPlatforms()
        {
            return await Context.Platforms
                .Select(o => o.MapTo<PlatformDto>())
                .OrderBy(o => o.Name)
                .ToListAsync();
        }

        public async Task<List<CustomerCategoryDto>> GetCustomerCategories()
        {
            return await Context.CustomerCategories
                .Select(o => o.MapTo<CustomerCategoryDto>())
                .OrderBy(o => o.Description)
                .ToListAsync();
        }

        public async Task<List<PlanDto>> GetPlans()
        {
            return await Context.Plans
                .Select(o => o.MapTo<PlanDto>())
                .OrderBy(o => o.Description)
                .ToListAsync();
        }

        public async Task<List<CustomerSituationDto>> GetCustomerSituations()
        {
            return await Context.CustomerSituations
                .Select(o => o.MapTo<CustomerSituationDto>())
                .OrderBy(o => o.Description)
                .ToListAsync();
        }

        public async Task<List<UserDto>> GetConsultants()
        {
            return await Context.Users
                .Where(o => o.UserTypeId == Const.UserTypes.Consultant)
                .Select(o => o.MapTo<UserDto>())
                .OrderBy(o => o.Name)
                .ToListAsync();
        }
    }
}
