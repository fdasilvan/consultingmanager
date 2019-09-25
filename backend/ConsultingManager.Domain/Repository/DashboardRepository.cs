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
    public class DashboardRepository : EfCoreRepositoryBase<ConsultingManagerDbContext, CustomerTaskPoco>, IRepository<CustomerTaskPoco>, IDashboardRepository
    {
        public DashboardRepository(IDbContextProvider<ConsultingManagerDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        #region Tasks

        public async Task<List<ChartResultDto>> GetCustomersDueTasks()
        {
            DateTime now = DateTime.Now;
            DateTime dateFilter = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);

            var list = await Context.CustomerTasks
                .Where(o => o.EndDate == null && o.EstimatedEndDate < dateFilter)
                .GroupBy(p => new { p.Customer.Id, p.Customer.Name })
                .Select(g => new ChartResultDto { Id = g.Key.Id, Description = g.Key.Name, Value = g.Count() })
                .ToListAsync();

            return list.OrderByDescending(o => o.Value).ToList();
        }

        public async Task<List<ChartResultDto>> GetCustomersOnTimeTasks()
        {
            DateTime now = DateTime.Now;
            DateTime dateFilter = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);

            var list = await Context.CustomerTasks
                .Where(o => o.EndDate == null && o.EstimatedEndDate < dateFilter && o.StartDate > dateFilter)
                .GroupBy(p => new { p.Customer.Id, p.Customer.Name })
                .Select(g => new ChartResultDto { Id = g.Key.Id, Description = g.Key.Name, Value = g.Count() })
                .ToListAsync();

            return list.OrderByDescending(o => o.Value).ToList();
        }

        public async Task<List<ChartResultDto>> GetConsultantsDueTasks()
        {
            DateTime now = DateTime.Now;
            DateTime dateFilter = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);

            var list = await Context.CustomerTasks
                .Include(o => o.Consultant)
                .Where(o => o.EndDate == null && dateFilter > o.StartDate && dateFilter < o.EstimatedEndDate)
                .GroupBy(p => new { p.Consultant.Id, p.Consultant.Name })
                .Select(g => new ChartResultDto { Id = g.Key.Id, Description = g.Key.Name, Value = g.Count() })
                .ToListAsync();

            return list.OrderByDescending(o => o.Value).ToList();
        }

        public async Task<List<ChartResultDto>> GetConsultantsOnTimeTasks()
        {
            DateTime now = DateTime.Now;
            DateTime dateFilter = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);

            var list = await Context.CustomerTasks
                .Include(o => o.Consultant)
                .Where(o => o.EndDate == null && dateFilter > o.StartDate && dateFilter < o.EstimatedEndDate)
                .GroupBy(p => new { p.Consultant.Id, p.Consultant.Name })
                .Select(g => new ChartResultDto { Id = g.Key.Id, Description = g.Key.Name, Value = g.Count() })
                .ToListAsync();

            return list.OrderByDescending(o => o.Value).ToList();
        }

        #endregion

        #region Meetings

        //public async Task<List<ChartResultDto>> GetCustomerPastMeetings()
        //{

        //}


        #endregion
    }
}
