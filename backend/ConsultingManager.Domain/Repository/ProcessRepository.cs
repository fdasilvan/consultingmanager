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
    public class ProcessRepository : EfCoreRepositoryBase<ConsultingManagerDbContext, ModelProcessPoco>, IRepository<ModelProcessPoco>, IProcessRepository
    {
        public ProcessRepository(IDbContextProvider<ConsultingManagerDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<ModelProcessDto>> GetAll()
        {
            return await Context.ModelProcesses
                .Select(process => process.MapTo<ModelProcessDto>())
                .ToListAsync();
        }

        public async Task<ModelProcessDto> Add(ModelProcessDto modelProcessoDto)
        {
            var newProcess = Context.ModelProcesses.Add(modelProcessoDto.MapTo<ModelProcessPoco>());
            await Context.SaveChangesAsync();
            return newProcess.Entity.MapTo<ModelProcessDto>();
        }

        public async Task<CustomerProcessDto> StartCustomerProcess(ModelProcessDto modelProcessDto, Guid customerId, Guid consultantId, Guid customerUserId, DateTime startDate)
        {
            CustomerProcessPoco customerProcess = new CustomerProcessPoco();

            List<ModelStepPoco> lstModelSteps = Context.ModelSteps
                .Include(o => o.ModelTasks)
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

                List<CustomerTaskPoco> lstTasks = new List<CustomerTaskPoco>();

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

                    lstTasks.Add(customerTask);
                }

                customerStep.CustomerTasks = lstTasks;
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

            CustomerProcessDto customerProcessDto = customerProcess.MapTo<CustomerProcessDto>();

            foreach (CustomerStepDto step in customerProcessDto.CustomerSteps)
            {
                step.CustomerProcess = null;

                foreach (CustomerTaskDto task in step.CustomerTasks)
                {
                    task.CustomerStep = null;
                }
            }

            return customerProcessDto;
        }

        public async Task<List<CustomerProcessDto>> GetCustomerTasks(Guid customerId)
        {
            List<CustomerProcessDto> processesList = await Context.CustomerProcesses
                .Include(process => process.CustomerSteps)
                    .ThenInclude(step => step.CustomerTasks)
                        .ThenInclude(task => task.Customer)
                .Include(process => process.CustomerSteps)
                    .ThenInclude(step => step.CustomerTasks)
                        .ThenInclude(task => task.CustomerUser)
                .Include(process => process.CustomerSteps)
                    .ThenInclude(step => step.CustomerTasks)
                        .ThenInclude(task => task.Consultant)
                .Include(process => process.CustomerSteps)
                    .ThenInclude(step => step.CustomerTasks)
                        .ThenInclude(task => task.Owner)
                .Include(process => process.CustomerSteps)
                    .ThenInclude(step => step.CustomerTasks)
                        .ThenInclude(task => task.TaskType)
                .Include(process => process.CustomerSteps)
                    .ThenInclude(step => step.CustomerTasks)
                        .ThenInclude(task => task.ModelTask)
                            .ThenInclude(modelTask => modelTask.TaskContent)
                .Where(process => process.CustomerId == customerId)
                .Select(process => process.MapTo<CustomerProcessDto>())
                .ToListAsync();

            foreach (CustomerProcessDto process in processesList)
            {
                foreach (CustomerStepDto step in process.CustomerSteps)
                {
                    step.CustomerProcess = null;

                    foreach (CustomerTaskDto task in step.CustomerTasks)
                    {
                        task.CustomerStep = null;
                    }
                }
            }

            return processesList;
        }
    }
}
