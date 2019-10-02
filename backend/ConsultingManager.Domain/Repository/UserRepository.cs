using ConsultingManager.Dto;
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
    public class UserRepository : EfCoreRepositoryBase<ConsultingManagerDbContext, UserPoco>, IRepository<UserPoco>, IUserRepository
    {
        public UserRepository(IDbContextProvider<ConsultingManagerDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<UserDto> Add(UserDto userDto)
        {
            var newUser = Context.Users.Add(userDto.MapTo<UserPoco>());
            await Context.SaveChangesAsync();
            return newUser.Entity.MapTo<UserDto>();
        }

        public async Task<UserDto> Authenticate(string email, string password)
        {
            var user = await Context.Users
                .Include(o => o.UserType)
                .Where(x => x.Email == email && x.Password == password)
                .Select(o => o.MapTo<UserDto>())
                .FirstOrDefaultAsync();

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so return user details without password
            user.Password = null;
            return user;
        }

        public async Task<List<CustomerMeetingDto>> GetUserMeetings(Guid userId)
        {
            var meetings = await Context.CustomerMeetings
                .Include(o => o.Customer)
                .Where(o => o.Customer.ConsultantId == userId)
                .Select(o => o.MapTo<CustomerMeetingDto>())
                .ToListAsync();

            return meetings;
        }

        public async Task<UserDto> GetUser(Guid userId)
        {
            var user = await Context.Users
                .Include(o => o.UserCustomerCategories)
                    .ThenInclude(o => o.CustomerCategory)
                .Include(o => o.UserCustomerLevels)
                    .ThenInclude(o => o.CustomerLevel)
                .Include(o => o.UserType)
                .Where(o => o.Id == userId)
                .FirstOrDefaultAsync();

            return user.MapTo<UserDto>();
        }

        public async Task<bool> SaveConsultant(UserDto userDto)
        {
            var consultantToEdit = await Context.Users
                .Include(o => o.UserCustomerCategories)
                .Include(o => o.UserCustomerLevels)
                .SingleOrDefaultAsync(o => o.Id == userDto.Id);

            if (consultantToEdit == null)
            {
                return false;
            }
            else
            {
                consultantToEdit = userDto.MapTo<UserPoco>();
                await Context.SaveChangesAsync();
                return true;
            }
        }
    }
}
