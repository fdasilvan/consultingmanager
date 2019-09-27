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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _processRepository.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao buscar atividades do cliente.");
            }
        }

        [HttpGet("model/{modelProcessId}")]
        public async Task<IActionResult> GetModel(Guid modelProcessId)
        {
            try
            {
                return Ok(await _processRepository.Get(modelProcessId));
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao buscar atividades do cliente.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Save(ModelProcessDto modelProcessDto)
        {
            return Ok(await _processRepository.Save(modelProcessDto));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid customerProcessId)
        {
            try
            {
                return Ok(await _processRepository.Delete(customerProcessId));
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao excluir ação do cliente.");
            }
        }

        [HttpPut("model/{modelStepId}/disable")]
        public async Task<IActionResult> DisableDisableModelStep(Guid modelStepId)
        {
            try
            {
                return Ok(await _processRepository.DisableModelStep(modelStepId));
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao desabilitar etapa:" + ex.Message);
            }
        }

        [HttpPost("start")]
        public async Task<IActionResult> StartCustomerProcess(StartCustomerProcessDto startCustomerProcessDto)
        {
            try
            {
                ModelProcessDto modelProcess = new ModelProcessDto();

                modelProcess.Id = startCustomerProcessDto.ModelProcessId;
                modelProcess.Description = startCustomerProcessDto.ModelProcessDescription;

                return Ok(await _processRepository.StartCustomerProcess(modelProcess, startCustomerProcessDto.CustomerId,
                    startCustomerProcessDto.ConsultantId, startCustomerProcessDto.CustomerUserId, startCustomerProcessDto.StartDate,
                    startCustomerProcessDto.Detail, startCustomerProcessDto.CustomerMeetingId));
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao iniciar processo do cliente.");
            }
        }

        [HttpGet("customer/{customerId}")]
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

        [HttpPost("step/{customerStepId}/finish")]
        public async Task<IActionResult> FinishStep(Guid customerStepId)
        {
            try
            {
                return Ok(await _processRepository.FinishStep(customerStepId));
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao finalizar etapa.");
            }
        }
    }
}