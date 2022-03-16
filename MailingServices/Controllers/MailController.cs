using MailingService.Models;
using Microsoft.AspNetCore.Mvc;
using static Emails;

namespace MailingServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MailController : ControllerBase
    {
        [HttpGet("sendEmail")]
        public  IActionResult SendEmail(SendEmailDto sendEmailDto)
        {
            List<string> recevers = new List<string>();
            recevers = sendEmailDto.Recevers;
            Emails.SendEmail(sendEmailDto.Subject,sendEmailDto.Body, recevers,null, Priority.Normal);
            return Ok("Email Sent");
        }
    }
}