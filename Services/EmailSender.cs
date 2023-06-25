using SMTPServer.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using MailKit;

namespace SMTPServer.Services
{
    public class MailService : IEmailSender {
        public readonly IConfiguration _config;

        public MailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<string> SendEmailAsync(MailRequest mailRequest){
            var message = new MimeMessage();

            mailRequest.ToEmails?.ForEach(email => {
                message.To.Add(MailboxAddress.Parse(email));
            });
            
            mailRequest.CCEmails?.ForEach(email => {
                message.Cc.Add(MailboxAddress.Parse(email));
            });

            message.Subject = mailRequest.Subject;

            message.Body = new TextPart(TextFormat.Html) { Text = mailRequest.Message };

            string host = "mail.smtp2go.com";
            int port = 2525;
            string email = "tcu687.website@gmail.com";
            string password = "O0rkK7gUJhS8CtWj";
            string response = "";
            
            message.From.Add(MailboxAddress.Parse(email));
            using (SmtpClient client = new SmtpClient()){
                client.Connect(host, port, SecureSocketOptions.StartTls);
                client.Authenticate(email, password);
                response = await client.SendAsync(message);
            }

            return response;
        }

    }


}

