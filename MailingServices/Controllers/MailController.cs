using Microsoft.AspNetCore.Mvc;
using static Emails;

namespace MailingServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MailController : ControllerBase
    {
      
        private readonly ILogger<MailController> _logger;
        //private readonly Mail _mail1;

        public MailController(ILogger<MailController> logger)
        {
            _logger = logger;
            //_mail1 = mail;
        }

        [HttpGet("Sender")]
       // [Route("Snder")]

        public  Task Send()
        {
            List<string> recevers = new List<string>();
            recevers.Add("kaddora1@gmail.com");
            recevers.Add("kaddora7@gmail.com");
            
            Emails.SendEmail("Testing","OOOOOOOOOO", recevers,null, Priority.Normal);
            return "h";
            
        }
    }
}