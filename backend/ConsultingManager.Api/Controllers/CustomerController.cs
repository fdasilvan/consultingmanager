using ConsultingManager.Domain.Repository;
using ConsultingManager.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsultingManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : TnfController
    {
        private ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> Get(Guid customerId)
        {
            return Ok(await _customerRepository.Get(customerId));
        }

        [HttpPost]
        public async Task<IActionResult> Add(CustomerDto customerDto)
        {
            return Ok(await _customerRepository.Add(customerDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(CustomerDto customerDto)
        {
            try
            {
                return Ok(await _customerRepository.Update(customerDto));
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao atualizar cliente: " + ex.Message);
            }
        }

        [HttpPut("transfer")]
        public async Task<IActionResult> Transfer(Guid customerId, Guid consultantId)
        {
            try
            {
                return Ok(await _customerRepository.Transfer(customerId, consultantId));
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao atualizar cliente: " + ex.Message);
            }
        }

        [HttpPost("{customerId}/meetings")]
        public async Task<IActionResult> AddMeetings(Guid customerId, List<CustomerMeetingDto> customerMeetingsDto)
        {
            try
            {
                return Ok(await _customerRepository.AddMeetings(customerId, customerMeetingsDto));
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao atualizar cliente: " + ex.Message);
            }
        }

        [HttpGet("{customerId}/meetings")]
        public async Task<IActionResult> GetMeetings(Guid customerId)
        {
            try
            {
                return Ok(await _customerRepository.GetMeetings(customerId));
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao atualizar cliente: " + ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _customerRepository.GetAll());
        }

        [HttpGet("cities")]
        public async Task<IActionResult> GetCities()
        {
            try
            {
                return Ok(await _customerRepository.GetCities());
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao buscar informações.");
            }
        }

        [HttpGet("platforms")]
        public async Task<IActionResult> GetPlatforms()
        {
            try
            {
                return Ok(await _customerRepository.GetPlatforms());
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao buscar informações.");
            }
        }

        [HttpGet("categories")]
        public async Task<IActionResult> GetCustomerCategories()
        {
            try
            {
                return Ok(await _customerRepository.GetCustomerCategories());
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao buscar informações.");
            }
        }

        [HttpGet("plans")]
        public async Task<IActionResult> GetPlans()
        {
            try
            {
                return Ok(await _customerRepository.GetPlans());
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao buscar informações.");
            }
        }

        [HttpGet("situations")]
        public async Task<IActionResult> GetCustomerSituations()
        {
            try
            {
                return Ok(await _customerRepository.GetCustomerSituations());
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao buscar informações.");
            }
        }

        [HttpGet("levels")]
        public async Task<IActionResult> GetCustomerLevels()
        {
            try
            {
                return Ok(await _customerRepository.GetCustomerLevels());
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao buscar informações.");
            }
        }

        [HttpGet("consultants")]
        public async Task<IActionResult> GetConsultants()
        {
            try
            {
                return Ok(await _customerRepository.GetConsultants());
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao buscar informações.");
            }
        }

        [HttpGet("teams")]
        public async Task<IActionResult> GetTeams()
        {
            try
            {
                return Ok(await _customerRepository.GetTeams());
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao buscar informações.");
            }
        }

        [HttpGet("cancellation-reasons")]
        public async Task<IActionResult> GetCancellationReasons()
        {
            try
            {
                return Ok(await _customerRepository.GetCancellationReasons());
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao buscar informações.");
            }
        }

        [HttpPost("cancellation")]
        public async Task<IActionResult> AddCustomerCancellation(CustomerCancellationDto customerCancellationDto)
        {
            return Ok(await _customerRepository.AddCustomerCancellation(customerCancellationDto));
        }

        [HttpPost("platform")]
        public async Task<IActionResult> AddPlatform(PlatformDto platformDto)
        {
            return Ok(await _customerRepository.AddPlatform(platformDto));
        }
    }
}