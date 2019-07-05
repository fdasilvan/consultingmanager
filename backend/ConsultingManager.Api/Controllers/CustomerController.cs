using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsultingManager.Domain.Repository;
using ConsultingManager.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public async Task<IActionResult> Add(CustomerDto customerDto)
        {
            return Ok(await _customerRepository.Add(customerDto));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _customerRepository.GetAll());
        }

        [HttpGet("chart")]
        public async Task<IActionResult> GetCustomersDueTasks()
        {
            try
            {
                return Ok(await _customerRepository.GetChartResult());
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao buscar informações.");
            }
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
    }
}