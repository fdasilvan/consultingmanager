using MimeKit;
using System.Threading.Tasks;

namespace ConsultingManager.Domain.Mailing
{
    public interface IMailingHelper
    {
        Task SendEmail(string toName, string toEmailAddress, string subject, string mailBody, string carbonCopyAddress);
    }
}