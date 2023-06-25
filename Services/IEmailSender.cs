using SMTPServer.Models;

namespace SMTPServer.Services
{
    public interface IEmailSender
    {
        Task<string> SendEmailAsync(MailRequest mailRequest);

    }
}