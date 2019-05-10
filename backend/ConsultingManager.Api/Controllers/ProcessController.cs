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
            return Ok(await _processRepository.StartCustomerProcess(modelProcessDto, customerId, consultantId, customerUserId, startDate));
        }
    }
}