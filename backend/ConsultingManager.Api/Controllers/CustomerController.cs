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
    }
}