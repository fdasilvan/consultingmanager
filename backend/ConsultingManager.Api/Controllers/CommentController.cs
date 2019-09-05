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
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;

        public CommentController(ICommentRepository commentRepository)
        {
            this._commentRepository = commentRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Add(CommentDto commentDto)
        {
            return Ok(await _commentRepository.Add(commentDto));
        }

        [HttpGet("meeting/{customerMeetingId}")]
        public async Task<IActionResult> GetMeetingComments(Guid customerMeetingId)
        {
            try
            {
                return Ok(await _commentRepository.GetMeetingComments(customerMeetingId));
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao buscar comentários do encontro.");
            }
        }

        [HttpGet("customer/{customerId}")]
        public async Task<IActionResult> GetCustomerComments(Guid customerId)
        {
            try
            {
                return Ok(await _commentRepository.GetCustomerComments(customerId));
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao buscar comentários do cliente.");
            }
        }
    }
}
