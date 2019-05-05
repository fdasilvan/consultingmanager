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
    public class ProcessRepository : EfCoreRepositoryBase<ConsultingManagerDbContext, ModelProcessPoco>, IRepository<ModelProcessPoco>
    {
        public ProcessRepository(IDbContextProvider<ConsultingManagerDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        //public async Task<List<CustomerDto>> GetCustomerProcess()
        //{
        //    return await Context.Processes
        //        .Include(o => o.)
        //        .Select(o => o.MapTo<CustomerDto>())
        //        .ToListAsync();
        //}
    }
}
