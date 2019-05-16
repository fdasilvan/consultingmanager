using ConsultingManager.Dto;
using ConsultingManager.Infra.Database;
using ConsultingManager.Infra.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
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

        public async Task<UserDto> Authenticate(string email, string password)
        {
            var user = await Context.Users
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
    }
}
