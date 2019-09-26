using ConsultingManager.Domain.Repository;
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

        [HttpGet("consultants/tasks")]
        public async Task<IActionResult> GetConsultantsTasks()
        {
            try
            {
                return Ok(await _dashboardRepository.GetConsultantsTasks());
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao buscar informações.");
            }
        }

        //[HttpGet("customers/tasks")]
        //public async Task<IActionResult> GetCustomersTasks()
        //{
        //    try
        //    {
        //        return Ok(await _dashboardRepository.GetConsultantsTasks());
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest("Erro ao buscar informações.");
        //    }
        //}

        #endregion
    }
}
