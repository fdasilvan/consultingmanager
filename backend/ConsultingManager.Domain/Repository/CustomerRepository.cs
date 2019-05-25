﻿using ConsultingManager.Dto;
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

        public async Task<List<CustomerDto>> GetAll()
        {
            return await Context.Customers
                .Include(o => o.Platform)
                .Include(o => o.Users)
                    .ThenInclude(o => o.UserType)
                .Select(o => o.MapTo<CustomerDto>())
                .ToListAsync();
        }

        public async Task<List<ChartResultDto>> GetChartResult()
        {
            return await Context.CustomerTasks
                .Where(o => o.EndDate == null && o.EstimatedEndDate < DateTime.Now)
                .GroupBy(p => new { p.Customer.Id, p.Customer.Name })
                .Select(g => new ChartResultDto { Description = g.Key.Name, Value = g.Count() })
                .ToListAsync();
        }
    }
}
