namespace MailingService.Models
{
    public class SendEmailDto
    {
        public List<string> Recevers { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
