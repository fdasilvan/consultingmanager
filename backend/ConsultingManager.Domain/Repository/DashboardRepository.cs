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
    public class DashboardRepository : EfCoreRepositoryBase<ConsultingManagerDbContext, CustomerTaskPoco>, IRepository<CustomerTaskPoco>, IDashboardRepository
    {
        public DashboardRepository(IDbContextProvider<ConsultingManagerDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        #region Tasks

        public async Task<List<CustomerTaskDto>> GetConsultantsTasks()
        {
            DateTime now = DateTime.Now;
            DateTime dateFilter = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);

            var list = await Context.CustomerTasks
                .Include(o => o.Consultant)
                .Include(o => o.Customer)
                .Include(o => o.TaskType)
                .Where(o => o.EndDate == null && o.Customer.SituationId == Const.CustomerSituations.Active)
                .Select(o => o.MapTo<CustomerTaskDto>())
                .ToListAsync();

            return list;
        }

        #endregion
    }
}
