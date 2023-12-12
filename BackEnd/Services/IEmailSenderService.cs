using BackEnd.Models;

namespace BackEnd.Services

{
    public interface IEmailSenderService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
