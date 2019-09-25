using ConsultingManager.Domain.Mailing;
using ConsultingManager.Domain.Repository;
using ConsultingManager.Dto;
using Mailing.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ConsultingManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardRepository _dashboardRepository;

        public DashboardController(IDashboardRepository dashboardRepository)
        {
            this._dashboardRepository = dashboardRepository;
        }

        #region Tasks

        [HttpGet("customers/tasks/due")]
        public async Task<IActionResult> GetCustomersDueTasks()
        {
            try
            {
                return Ok(await _dashboardRepository.GetCustomersDueTasks());
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao buscar informações.");
            }
        }

        [HttpGet("customers/tasks/on-time")]
        public async Task<IActionResult> GetCustomersOnTimeTasks()
        {
            try
            {
                return Ok(await _dashboardRepository.GetCustomersOnTimeTasks());
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao buscar informações.");
            }
        }

        [HttpGet("consultants/tasks/due")]
        public async Task<IActionResult> GetConsultantsDueTasks()
        {
            try
            {
                return Ok(await _dashboardRepository.GetConsultantsDueTasks());
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao buscar informações.");
            }
        }

        [HttpGet("consultants/tasks/on-time")]
        public async Task<IActionResult> GetConsultantsOnTimeTasks()
        {
            try
            {
                return Ok(await _dashboardRepository.GetConsultantsOnTimeTasks());
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao buscar informações.");
            }
        }

        #endregion

        #region Meetings

        [HttpGet("customer/meetings/past")]
        public async Task<IActionResult> GetCustomerPastMeetings()
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao buscar informações.");
            }
        }

        [HttpGet("customer/meetings/future")]
        public async Task<IActionResult> GetCustomerFutureMeetings()
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao buscar informações.");
            }
        }

        [HttpGet("consultant/meetings/past")]
        public async Task<IActionResult> GetConsultantPastMeetings()
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao buscar informações.");
            }
        }

        [HttpGet("consultant/meetings/future")]
        public async Task<IActionResult> GetConsultantFutureMeetings()
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao buscar informações.");
            }
        }

        [HttpGet("customer/meetings/processes")]
        public async Task<IActionResult> GetCustomerMeetingsProcesses()
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao buscar informações.");
            }
        }

        [HttpGet("consultant/meetings")]
        public async Task<IActionResult> GetConsultantMeetingsProcesses()
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao buscar informações.");
            }
        }

        #endregion
    }
}
