using SMTPServer.Models;
using SMTPServer.Services;
using Microsoft.AspNetCore.Mvc;

namespace SMTPServer.Controllers
{
    [Route("api/")]
    [ApiController]
    public class EmailSenderController : Controller
    {
        private readonly IEmailSender _emailSender;
        public EmailSenderController(IEmailSender emailSender) {
            _emailSender = emailSender;
        }

        [HttpPost("sendEmail")]
        public async Task<ActionResult> SendEmailAsync(MailRequest mailRequest) {
            try{
                string response = await _emailSender.SendEmailAsync(mailRequest);
                if (response.Contains("OK")){
                    return Ok(response);
                }
                return BadRequest(response);
            } catch (Exception ex){
                return BadRequest(ex.Message);
            }
        }
    }
    
}