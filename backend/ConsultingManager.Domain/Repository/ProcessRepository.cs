﻿using ConsultingManager.Dto;
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
                .Include(o => o.ModelSteps)
                .ThenInclude(p => p.ModelTasks)
                .Select(process => process.MapTo<ModelProcessDto>())
                .ToListAsync();
        }

        public async Task<bool> Save(ModelProcessDto modelProcessDto)
        {
            try
            {
                var modelProcessToEdit = await Context.ModelProcesses.SingleOrDefaultAsync(o => o.Id == modelProcessDto.Id);

                if (modelProcessToEdit == null)
                {
                    var newProcess = Context.ModelProcesses.Add(modelProcessDto.MapTo<ModelProcessPoco>());
                }
                else
                {
                    modelProcessToEdit.Description = modelProcessDto.Description;

                    foreach (ModelStepDto step in modelProcessDto.ModelSteps)
                    {
                        ModelStepPoco modelStepPoco = Context.ModelSteps.FirstOrDefault(o => o.Id == step.Id);

                        if (modelStepPoco == null)
                        {
                            var newStep = Context.ModelSteps.Add(step.MapTo<ModelStepPoco>());
                        }
                        else
                        {
                            modelStepPoco.Description = step.Description;
                            modelStepPoco.ProcessId = modelProcessToEdit.Id;

                            foreach (ModelTaskDto task in step.ModelTasks)
                            {
                                ModelTaskPoco modelTaskPoco = Context.ModelTasks.FirstOrDefault(o => o.Id == task.Id);

                                if (modelTaskPoco == null)
                                {
                                    var newTask = Context.ModelTasks.Add(task.MapTo<ModelTaskPoco>());
                                }
                                else
                                {
                                    modelTaskPoco.ModelStepId = step.Id;
                                    modelTaskPoco.Description = task.Description;
                                    modelTaskPoco.TaskTypeId = task.TaskTypeId;
                                    modelTaskPoco.Instructions = task.Instructions;
                                    modelTaskPoco.Duration = task.Duration;
                                    modelTaskPoco.StartAfterDays = task.StartAfterDays;
                                    modelTaskPoco.DueDays = task.DueDays;
                                }
                            }
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
                .Where(process => process.CustomerId == customerId)
                .Select(process => process.MapTo<CustomerProcessDto>())
                .ToListAsync();

            foreach (CustomerProcessDto customerProcess in processesList)
            {
                foreach (CustomerStepDto customerStep in customerProcess.CustomerSteps)
                {
                    List<CustomerTaskDto> customerTasks = await Context.CustomerTasks
                            .Include(task => task.Customer)
                            .Include(task => task.CustomerUser)
                            .Include(task => task.Consultant)
                            .Include(task => task.Owner)
                            .Include(task => task.TaskType)
                            .Include(task => task.ModelTask)
                                .ThenInclude(modelTask => modelTask.TaskContent)
                        .Where(o => o.CustomerStepId == customerStep.Id)
                        .Select(task => task.MapTo<CustomerTaskDto>())
                        .ToListAsync();

                    customerStep.CustomerTasks = customerTasks;
                }
            }

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
