using ConsultingManager.Dto;
using ConsultingManager.Infra;
using ConsultingManager.Infra.Database;
using ConsultingManager.Infra.Database.Models;
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

        public async Task<CustomerProcessDto> StartCustomerProcess(ModelProcessDto modelProcessDto, Guid customerId, Guid consultantId, Guid customerUserId, DateTime startDate)
        {
            CustomerProcessPoco customerProcess = new CustomerProcessPoco();

            List<ModelStepPoco> lstModelSteps = Context.ModelSteps
                .Where(o => o.ProcessId == modelProcessDto.Id)
                .ToList();

            List<CustomerStepPoco> lstCustomerSteps = new List<CustomerStepPoco>();

            DateTime? processEstimatedEndDate = null;

            foreach (ModelStepPoco modelStep in lstModelSteps)
            {
                CustomerStepPoco customerStep = new CustomerStepPoco();

                customerStep.Id = Guid.NewGuid();

                DateTime? firstDate = null;
                DateTime? lastDate = null;

                foreach (ModelTaskPoco modelTask in modelStep.ModelTasks)
                {
                    CustomerTaskPoco customerTask = new CustomerTaskPoco();

                    customerTask.Id = Guid.NewGuid();
                    customerTask.CustomerStepId = customerStep.Id;
                    customerTask.ModelTaskId = modelTask.Id;

                    customerTask.Description = modelTask.Description;
                    customerTask.Instructions = modelTask.Instructions;
                    customerTask.Duration = modelTask.Duration;
                    customerTask.CreationDate = DateTime.Now;

                    customerTask.StartDate = Utils.AddBusinessDays(startDate, modelTask.StartAfterDays);
                    firstDate = (firstDate == null || customerTask.StartDate < firstDate ? customerTask.StartDate : firstDate);
                    customerTask.EstimatedEndDate = Utils.AddBusinessDays(customerTask.StartDate, modelTask.DueDays);
                    lastDate = (lastDate == null || customerTask.EstimatedEndDate > lastDate ? customerTask.EstimatedEndDate : lastDate);
                    processEstimatedEndDate = (processEstimatedEndDate == null || lastDate > processEstimatedEndDate ? lastDate : processEstimatedEndDate);

                    customerTask.EndDate = null;

                    customerTask.CustomerId = customerId;
                    customerTask.CustomerUserId = customerUserId;
                    customerTask.ConsultantId = consultantId;

                    if (modelTask.TaskTypeId == Const.TaskTypes.Customer)
                    {
                        customerTask.TaskTypeId = Const.TaskTypes.Customer;
                        customerTask.OwnerId = customerUserId;
                    }
                    else
                    {
                        customerTask.TaskTypeId = Const.TaskTypes.Consultant;
                        customerTask.OwnerId = consultantId;
                    }
                }

                customerStep.StartDate = (firstDate.HasValue ? firstDate.Value : throw new Exception("Data inicial da etapa não definida."));
                customerStep.EstimatedEndDate = (lastDate.HasValue ? lastDate.Value : throw new Exception("Data final da etapa não definida"));
                customerStep.EndDate = null;
                customerStep.Description = modelStep.Description;
                customerStep.ModelStepId = modelStep.Id;

                lstCustomerSteps.Add(customerStep);
            }

            customerProcess.Id = new Guid();
            customerProcess.Description = modelProcessDto.Description;
            customerProcess.ModelProcessId = modelProcessDto.Id;
            customerProcess.CustomerId = customerId;
            customerProcess.StartDate = startDate;
            customerProcess.CustomerSteps = lstCustomerSteps;
            customerProcess.EstimatedEndDate = (processEstimatedEndDate.HasValue ? processEstimatedEndDate.Value : throw new Exception("Data final do processo não definida"));
            customerProcess.EndDate = null;

            Context.CustomerProcesses.Add(customerProcess);
            await Context.SaveChangesAsync();

            return customerProcess.MapTo<CustomerProcessDto>();
        }
    }
}
