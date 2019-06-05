using ConsultingManager.Domain.Repository;
using ConsultingManager.Dto;
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

        [HttpPost("{taskId}/finish")]
        public async Task<IActionResult> FinishTask(Guid taskId)
        {
            try
            {
                return Ok(await _taskRepository.FinishTask(taskId));
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao finalizar atividade.");
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
                return BadRequest("Erro ao finalizar atividade.");
            }
        }

        [HttpPost("{taskId}/reschedule/{newDate}")]
        public async Task<IActionResult> FinishTask(Guid taskId, DateTime newDate)
        {
            try
            {
                return Ok(await _taskRepository.RescheduleTask(taskId, newDate));
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao finalizar atividade.");
            }
        }
    }
}