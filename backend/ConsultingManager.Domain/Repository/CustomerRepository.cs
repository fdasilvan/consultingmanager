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
            await Context.SaveChangesAsync();
            return newCustomer.Entity.MapTo<CustomerDto>();
        }

        public async Task<CustomerDto> Update(CustomerDto customerDto)
        {
            var customer = Context.Customers.FirstOrDefaultAsync(o => o.Id == customerDto.Id).Result;

            if (customer != null)
            {
                customer.Name = customerDto.Name;
                customer.ExternalId = customerDto.ExternalId;
                customer.SituationId = customerDto.SituationId;
                customer.CustomerLevelId = customerDto.CustomerLevelId;
                customer.Email = customerDto.Email;
                customer.Phone = customerDto.Phone;
                customer.LogoUrl = customerDto.LogoUrl;
                customer.StoreUrl = customerDto.StoreUrl;
                customer.CityId = customerDto.CityId;
                customer.PlatformId = customerDto.PlatformId;
                customer.CategoryId = customerDto.CategoryId;
                customer.PlanId = customerDto.PlanId;
                customer.ConsultantId = customerDto.ConsultantId;
                customer.CustomerFolderUrl = customerDto.CustomerFolderUrl;
                customer.StoreAnalysisUrl = customerDto.StoreAnalysisUrl;
                customer.MeetingsDescription = customerDto.MeetingsDescription;
                customer.Subcategory = customerDto.Subcategory;
                customer.TeamId = customerDto.TeamId;

                var updatedCustomer = Context.Customers.Update(customer);
                await Context.SaveChangesAsync();
                return updatedCustomer.Entity.MapTo<CustomerDto>();
            }
            else
            {
                throw new Exception("Não foi possível atualizar o cliente: " + customerDto.Name);
            }
        }

        public async Task<CustomerDto> Transfer(Guid customerId, Guid consultantId)
        {
            var customer = Context.Customers.FirstOrDefaultAsync(o => o.Id == customerId).Result;

            if (customer != null)
            {
                customer.ConsultantId = consultantId;

                var updatedCustomer = Context.Customers.Update(customer);

                var customerTasks = await Context.CustomerTasks
                    .Include(o => o.Consultant)
                    .Include(o => o.Customer)
                    .Include(o => o.TaskType)
                    .Where(o => o.EndDate == null && o.Customer.Id == customerId)
                    .ToListAsync();

                foreach (CustomerTaskPoco customerTask in customerTasks)
                {
                    customerTask.OwnerId = consultantId;
                    Context.CustomerTasks.Update(customerTask);
                }

                await Context.SaveChangesAsync();
                return updatedCustomer.Entity.MapTo<CustomerDto>();
            }
            else
            {
                throw new Exception("Não foi possível transferir o cliente: " + customerId);
            }
        }

        public async Task<List<CustomerMeetingDto>> GetMeetings(Guid customerId)
        {
            try
            {
                return await Context.CustomerMeetings
                    .Include(o => o.Customer)
                        .ThenInclude(o => o.Plan)
                    .Where(o => o.CustomerId == customerId)
                    .Select(o => o.MapTo<CustomerMeetingDto>())
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> AddMeetings(Guid customerId, List<CustomerMeetingDto> customerMeetings)
        {
            try
            {
                foreach (CustomerMeetingDto customerMeetingDto in customerMeetings)
                {
                    if (customerId == customerMeetingDto.CustomerId)
                    {
                        var customerMeetingToEdit = await Context.CustomerMeetings.SingleOrDefaultAsync(o => o.Id == customerMeetingDto.Id);

                        if (customerMeetingToEdit == null)
                        {
                            var lst = Context.CustomerMeetings.Add(customerMeetingDto.MapTo<CustomerMeetingPoco>());
                        }
                        else
                        {
                            customerMeetingToEdit.Date = customerMeetingDto.Date;
                        }
                    }
                }
                await Context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CustomerDto> Get(Guid customerId)
        {
            var customer = await Context.Customers
                .Include(o => o.Platform)
                .Include(o => o.Plan)
                .Include(o => o.Situation)
                .Include(o => o.Category)
                .Include(o => o.Users)
                .Include(o => o.Team)
                .Include(o => o.Consultant)
                    .ThenInclude(o => o.UserType)
                .Include(o => o.CustomerLevel)
                .FirstOrDefaultAsync(o => o.Id == customerId);

            return customer.MapTo<CustomerDto>();
        }

        public async Task<List<CustomerDto>> GetAll()
        {
            return await Context.Customers
                .Include(o => o.Platform)
                .Include(o => o.Plan)
                .Include(o => o.Situation)
                .Include(o => o.Category)
                .Include(o => o.Users)
                .Include(o => o.Consultant)
                    .ThenInclude(o => o.UserType)
                .Include(o => o.CustomerLevel)
                .OrderBy(o => o.Name)
                .Select(o => o.MapTo<CustomerDto>())
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

        public async Task<List<CustomerLevelDto>> GetCustomerLevels()
        {
            return await Context.CustomerLevels
                .Select(o => o.MapTo<CustomerLevelDto>())
                .OrderBy(o => o.Description)
                .ToListAsync();
        }

        public async Task<List<CustomerContactDto>> GetCustomerContacts(Guid customerId)
        {
            return await Context.CustomerContacts
                .Select(o => o.MapTo<CustomerContactDto>())
                .Where(o => o.CustomerId == customerId)
                .OrderBy(o => o.Name)
                .ToListAsync();
        }

        public async Task<bool> AddCustomer(Guid customerId, List<CustomerContactDto> customerContacts)
        {
            try
            {
                foreach (CustomerContactDto customerContactDto in customerContacts)
                {
                    if (customerId == customerContactDto.CustomerId)
                    {
                        var customerContactToEdit = await Context.CustomerContacts.SingleOrDefaultAsync(o => o.Id == customerContactDto.Id);

                        if (customerContactToEdit == null)
                        {
                            var lst = Context.CustomerContacts.Add(customerContactDto.MapTo<CustomerContactPoco>());
                        }
                        else
                        {
                            customerContactToEdit.Name = customerContactDto.Name;
                            customerContactToEdit.Email = customerContactDto.Email;
                            customerContactToEdit.Role = customerContactDto.Role;
                            customerContactToEdit.Phone = customerContactDto.Phone;
                        }
                    }
                }
                await Context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<UserDto>> GetConsultants()
        {
            return await Context.Users
                .Where(o => o.UserTypeId == Const.UserTypes.Consultant || o.UserTypeId == Const.UserTypes.Leader || o.UserTypeId == Const.UserTypes.Specialist || o.UserTypeId == Const.UserTypes.Implanter)
                .Select(o => o.MapTo<UserDto>())
                .OrderBy(o => o.Name)
                .ToListAsync();
        }

        public async Task<List<TeamDto>> GetTeams()
        {
            return await Context.Teams
                .Select(o => o.MapTo<TeamDto>())
                .OrderByDescending(o => o.Description)
                .ToListAsync();
        }

        public async Task<List<CancellationReasonDto>> GetCancellationReasons()
        {
            return await Context.CancellationReasons
                .Select(o => o.MapTo<CancellationReasonDto>())
                .OrderByDescending(o => o.Description)
                .ToListAsync();
        }

        public async Task<PlatformDto> AddPlatform(PlatformDto platformDto)
        {
            var newCustomer = Context.Platforms.Add(platformDto.MapTo<PlatformPoco>());
            await Context.SaveChangesAsync();
            return newCustomer.Entity.MapTo<PlatformDto>();
        }

        public async Task<CustomerCancellationDto> AddCustomerCancellation(CustomerCancellationDto customerCancellationDto)
        {
            var newCustomerCancellation = Context.CustomerCancellations.Add(customerCancellationDto.MapTo<CustomerCancellationPoco>());
            await Context.SaveChangesAsync();
            return newCustomerCancellation.Entity.MapTo<CustomerCancellationDto>();
        }
    }
}
