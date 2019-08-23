using ConsultingManager.Dto;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using System;
using System.Threading.Tasks;

namespace ConsultingManager.Domain.Mailing
{
    public class MailingHelper : IMailingHelper
    {
        private readonly IOptions<MailingConfigDto> _mailingConfig;

        public MailingHelper(IOptions<MailingConfigDto> mailingConfig)
        {
            _mailingConfig = mailingConfig;
        }

        public async Task SendEmail(string toName, string toEmailAddress, string subject, string mailBody)
        {
            try
            {
                MimeMessage message = new MimeMessage();
                message.From.Add(new MailboxAddress(_mailingConfig.Value.FromName, _mailingConfig.Value.FromAddress));
                message.To.Add(new MailboxAddress(toName, toEmailAddress));
                message.Subject = subject;

                TextPart textPart = new TextPart(TextFormat.Html)
                {
                    Text = mailBody
                };
                message.Body = textPart;

                using (SmtpClient client = new SmtpClient())
                {
                    client.Connect(_mailingConfig.Value.SmtpAddress, _mailingConfig.Value.SmtpPort, _mailingConfig.Value.SmtpUseSsl);
                    client.Authenticate(_mailingConfig.Value.FromAddress, _mailingConfig.Value.Password);
                    await client.SendAsync(message);
                    client.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
