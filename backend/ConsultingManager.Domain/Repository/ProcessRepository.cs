using ConsultingManager.Dto;
using ConsultingManager.Infra.Database;
using ConsultingManager.Infra.Database.Models;
using Microsoft.AspNetCore.Mvc;
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
    public class ProcessRepository : EfCoreRepositoryBase<ConsultingManagerDbContext, ModelProcessPoco>, IRepository<ModelProcessPoco>, IProcessRepository
    {
        public ProcessRepository(IDbContextProvider<ConsultingManagerDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
        
        public async Task<CustomerProcessDto> StartCustomerProcess(ModelProcessDto modelProcessDto, Guid customerId)
        {
            CustomerProcessPoco customerProcess = new CustomerProcessPoco();

            #region Get steps list

            List<ModelStepPoco> lstModelSteps = Context.ModelSteps
                .Where(o => o.ProcessId == modelProcessDto.Id)
                .ToList();

            List<CustomerStepPoco> lstCustomerSteps = new List<CustomerStepPoco>();

            foreach(ModelStepPoco modelStep in lstModelSteps)
            {
                CustomerStepPoco customerStep = new CustomerStepPoco();

                customerStep.Id = Guid.NewGuid();
                customerStep.Description = modelStep.Description;
                customerStep.ModelStepId = modelStep.Id;

                lstCustomerSteps.Add(customerStep);
            }

            #endregion

            customerProcess.Id = new Guid();
            customerProcess.Description = modelProcessDto.Description;
            customerProcess.ModelProcessId = modelProcessDto.Id;
            customerProcess.CustomerId = customerId;
            customerProcess.StartDate = DateTime.Now;
            customerProcess.CustomerSteps = lstCustomerSteps;
            customerProcess.EstimatedEndDate = null;
            customerProcess.EndDate = null;

            Context.CustomerProcesses.Add(customerProcess);
            await Context.SaveChangesAsync();

            return customerProcess.MapTo<CustomerProcessDto>();
        }
    }
}
