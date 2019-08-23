namespace ConsultingManager.Dto
{
    public class MailingConfigDto
    {
        public string FromName { get; set; }
        public string FromAddress { get; set; }
        public string Password { get; set; }
        public string SmtpAddress { get; set; }
        public int SmtpPort { get; set; }
        public bool SmtpUseSsl { get; set; }
        public string UserActivationApi { get; set; }
    }
}
