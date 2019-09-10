using ConsultingManager.Domain.Mailing;
using ConsultingManager.Dto;
using ConsultingManager.Infra.Database;
using ConsultingManager.Infra.Database.Models;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tnf.EntityFrameworkCore;
using Tnf.EntityFrameworkCore.Repositories;
using Tnf.Repositories;

namespace ConsultingManager.Domain.Repository
{
    public class TaskRepository : EfCoreRepositoryBase<ConsultingManagerDbContext, ModelTaskPoco>, IRepository<ModelTaskPoco>, ITaskRepository
    {
        IMailingHelper _mailingHelper;
        public TaskRepository(IDbContextProvider<ConsultingManagerDbContext> dbContextProvider,
            IMailingHelper mailingHelper) : base(dbContextProvider)
        {
            _mailingHelper = mailingHelper;
        }

        public async Task<List<CustomerTaskDto>> GetUserTasks(Guid userId)
        {
            return await Context.CustomerTasks
                .Include(task => task.Owner)
                .Include(task => task.Customer)
                .Include(task => task.Consultant)
                .Include(task => task.Customer)
                .Include(task => task.CustomerUser)
                .Include(task => task.TaskType)
                .Include(task => task.ModelTask).ThenInclude(modelTask => modelTask.TaskContent)
                .Where(task => task.OwnerId == userId && task.EndDate == null && task.StartDate < DateTime.Now)
                .Select(task => task.MapTo<CustomerTaskDto>())
                .ToListAsync();
        }

        public async Task<CustomerTaskDto> GetTask(Guid taskId)
        {
            CustomerTaskDto customerTask = await Context.CustomerTasks
                .Include(task => task.Owner)
                .Include(task => task.Customer)
                .Include(task => task.Consultant)
                .Include(task => task.Customer)
                .Include(task => task.CustomerUser)
                .Include(task => task.TaskType)
                .Include(task => task.CustomerStep).ThenInclude(task => task.CustomerProcess)
                .Include(task => task.ModelTask).ThenInclude(modelTask => modelTask.TaskContent)
                .Where(task => task.Id == taskId)
                .Select(task => task.MapTo<CustomerTaskDto>())
                .SingleOrDefaultAsync();

            customerTask.CustomerStep.CustomerProcess.CustomerSteps = null;
            customerTask.CustomerStep.CustomerTasks = null;

            return customerTask;
        }

        public async Task<CustomerTaskDto> FinishTask(Guid taskId)
        {
            CustomerTaskPoco task = await Context.CustomerTasks
                .Include(o => o.Customer)
                .Include(o => o.CustomerUser)
                .Include(o => o.Consultant)
                .Where(o => o.Id == taskId)
                .FirstOrDefaultAsync();

            task.EndDate = DateTime.Now;
            await Context.SaveChangesAsync();

            if (!string.IsNullOrEmpty(task.MailSubject) && (!string.IsNullOrEmpty(task.MailBody)))
            {
                string toName = task.CustomerUser.Name;
                string toEmailAddress = task.CustomerUser.Email;
                string carbonCopyAddress = task.Consultant.Email;

                string mailSubject = task.MailSubject;
                mailSubject = mailSubject.Replace("{{NomeCliente}}", task.Customer.Name);
                mailSubject = mailSubject.Replace("{{NomeUsuarioCliente}}", task.CustomerUser.Name);
                mailSubject = mailSubject.Replace("{{UrlLoja}}", task.Customer.StoreUrl);
                mailSubject = mailSubject.Replace("{{NomeConsultor}}", task.Consultant.Name);
                mailSubject = mailSubject.Replace("{{SalaConsultor}}", task.Consultant.ConferenceRoomAddress);
                mailSubject = mailSubject.Replace("{{DataInicial}}", task.StartDate.ToShortDateString());
                mailSubject = mailSubject.Replace("{{DataFinal}}", task.EstimatedEndDate.ToShortDateString());

                string mailBody = task.MailBody;
                mailBody = mailBody.Replace("{{NomeCliente}}", task.Customer.Name);
                mailBody = mailBody.Replace("{{NomeUsuarioCliente}}", task.CustomerUser.Name);
                mailBody = mailBody.Replace("{{UrlLoja}}", task.Customer.StoreUrl);
                mailBody = mailBody.Replace("{{NomeConsultor}}", task.Consultant.Name);
                mailBody = mailBody.Replace("{{SalaConsultor}}", task.Consultant.ConferenceRoomAddress);
                mailBody = mailBody.Replace("{{DataInicial}}", task.StartDate.ToShortDateString());
                mailBody = mailBody.Replace("{{DataFinal}}", task.EstimatedEndDate.ToShortDateString());
                mailBody = mailBody.Replace("\n", "<br>");

                await _mailingHelper.SendEmail(toName, toEmailAddress, mailSubject, mailBody, carbonCopyAddress);
            }

            return task.MapTo<CustomerTaskDto>();
        }

        public async Task<CustomerTaskDto> ReopenTask(Guid taskId)
        {
            CustomerTaskPoco task = await Context.CustomerTasks
                .Where(o => o.Id == taskId)
                .FirstOrDefaultAsync();

            task.EndDate = null;
            await Context.SaveChangesAsync();
            return task.MapTo<CustomerTaskDto>();
        }

        public async Task<CustomerTaskDto> RescheduleTask(Guid taskId, DateTime newDate)
        {
            if (newDate.DayOfYear < DateTime.Now.DayOfYear)
            {
                throw new Exception("Não é possível reprogramar a tarefa para uma data passada.");
            }

            CustomerTaskPoco task = await Context.CustomerTasks
                .Where(o => o.Id == taskId)
                .FirstOrDefaultAsync();

            task.EstimatedEndDate = newDate;
            await Context.SaveChangesAsync();
            return task.MapTo<CustomerTaskDto>();
        }

        public async Task<CustomerTaskDto> TransferTask(Guid taskId, Guid consultantId)
        {
            CustomerTaskPoco task = await Context.CustomerTasks
                .Where(o => o.Id == taskId)
                .FirstOrDefaultAsync();

            task.OwnerId = consultantId;
            await Context.SaveChangesAsync();
            return task.MapTo<CustomerTaskDto>();
        }
    }
}
