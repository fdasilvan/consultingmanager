using ConsultingManager.Domain.Repository;
using ConsultingManager.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ConsultingManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessController : ControllerBase
    {
        private IProcessRepository _processRepository;

        public ProcessController(IProcessRepository processRepository)
        {
            _processRepository = processRepository;
        }

        [HttpPost]
        public async Task<IActionResult> StartCustomerProcess([FromBody]ModelProcessDto modelProcessDto, Guid customerId, Guid consultantId, Guid customerUserId, DateTime startDate)
        {
            try
            {
                return Ok(await _processRepository.StartCustomerProcess(modelProcessDto, customerId, consultantId, customerUserId, startDate));
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao iniciar processo do cliente.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomerTasks(Guid customerId)
        {
            try
            {
                return Ok(await _processRepository.GetCustomerTasks(customerId));
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao buscar atividades do cliente.");
            }
        }

        [HttpPost("finish-task/{taskId}")]
        public async Task<IActionResult> FinishTask(Guid taskId)
        {
            try
            {
                return Ok(await _processRepository.FinishTask(taskId));
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao finalizar atividade.");
            }
        }
    }
}