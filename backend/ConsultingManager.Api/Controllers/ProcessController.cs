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

        [HttpPost]
        public async Task<IActionResult> Save(ModelProcessDto modelProcessDto)
        {
            return Ok(await _processRepository.Save(modelProcessDto));
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
                    startCustomerProcessDto.CustomerMeetingId));
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
    }
}