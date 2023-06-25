namespace SMTPServer.Models
{
    public class MailRequest
    {
        public MailRequest()
        {
            this.ToEmails = new List<string>();
            this.CCEmails = new List<string>();
        }
        public List<string> ToEmails { get; set; }
        public List<string> CCEmails { get; set; }
        public string? FromEmail { get; set; }
        public string? FromName { get; set; }
        public string? Subject { get; set; }
        public string? Message { get; set; }
    }
}