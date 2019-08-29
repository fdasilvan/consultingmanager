namespace Mailing.Dto
{
    public class MailDto
    {
        public string ToName { get; set; }
        public string ToEmailAddress { get; set; }
        public string Subject { get; set; }
        public string MailBody { get; set; }
        public string CarbonCopyAddress { get; set; }
    }
}
