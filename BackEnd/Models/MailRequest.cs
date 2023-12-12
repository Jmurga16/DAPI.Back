namespace BackEnd.Models
{
    public class MailRequest
    {
        public string Email { get; set; } = String.Empty;
        public string Subject { get; set; } = String.Empty;
        public string Body { get; set; } = String.Empty;
    }
}
