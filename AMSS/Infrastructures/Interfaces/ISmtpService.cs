
using AMSS.Dto.Requests.Mails;
using MailKit.Net.Smtp;

namespace AMSS.Infrastructures.Interfaces
{
    public interface ISmtpService
    {
        Task<SmtpResponse> SendEmailAsync(MailRequest mailRequest);
    }
}
