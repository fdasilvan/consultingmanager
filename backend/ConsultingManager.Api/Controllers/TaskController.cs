using ConsultingManager.Domain.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ConsultingManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private ITaskRepository _taskRepository;

        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserTasks(Guid userId)
        {
            try
            {
                return Ok(await _taskRepository.GetUserTasks(userId));
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao buscar atividades do cliente.");
            }
        }

        [HttpGet("{taskId}")]
        public async Task<IActionResult> GetTask(Guid taskId)
        {
            try
            {
                return Ok(await _taskRepository.GetTask(taskId));
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao buscar tarefa " + taskId);
            }
        }

        [HttpPost("{taskId}/finish")]
        public async Task<IActionResult> FinishTask(Guid taskId)
        {
            try
            {
                return Ok(await _taskRepository.FinishTask(taskId));
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao finalizar tarefa.");
            }
        }

        [HttpPost("{taskId}/reopen")]
        public async Task<IActionResult> ReopenTask(Guid taskId)
        {
            try
            {
                return Ok(await _taskRepository.ReopenTask(taskId));
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao reabrir tarefa.");
            }
        }

        [HttpPost("{taskId}/reschedule/{newDate}")]
        public async Task<IActionResult> RescheduleTask(Guid taskId, DateTime newDate)
        {
            try
            {
                return Ok(await _taskRepository.RescheduleTask(taskId, newDate));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("step/{customerStepId}/reschedule/{businessDaysToAdd}")]
        public async Task<IActionResult> RescheduleStep(Guid customerStepId, int businessDaysToAdd)
        {
            try
            {
                return Ok(await _taskRepository.RescheduleStep(customerStepId, businessDaysToAdd));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("process/{customerProcessId}/reschedule/{businessDaysToAdd}")]
        public async Task<IActionResult> RescheduleProcess(Guid customerProcessId, int businessDaysToAdd)
        {
            try
            {
                return Ok(await _taskRepository.RescheduleProcess(customerProcessId, businessDaysToAdd));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{taskId}/anticipate")]
        public async Task<IActionResult> AnticipateTask(Guid taskId)
        {
            try
            {
                return Ok(await _taskRepository.AnticipateTask(taskId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{taskId}/transfer/{consultantId}")]
        public async Task<IActionResult> TransferTask(Guid taskId, Guid consultantId)
        {
            try
            {
                return Ok(await _taskRepository.TransferTask(taskId, consultantId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}