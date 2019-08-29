using ConsultingManager.Domain.Mailing;
using Mailing.Dto;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ConsultingManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailingController : ControllerBase
    {
        private readonly IMailingHelper _mailingHelper;

        public MailingController(IMailingHelper mailingHelper)
        {
            this._mailingHelper = mailingHelper;
        }

        [HttpPost("send")]
        public IActionResult SendMail(MailDto mailDto)
        {
            try
            {
                _mailingHelper.SendEmail(mailDto.ToName, mailDto.ToEmailAddress, mailDto.Subject, mailDto.MailBody, mailDto.CarbonCopyAddress);
                return Ok("E-mail enviado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
