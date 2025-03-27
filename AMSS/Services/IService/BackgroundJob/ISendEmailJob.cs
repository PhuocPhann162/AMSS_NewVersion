using AMSS.Constants;
using AMSS.Dto.Requests.Mails;
using Hangfire;

namespace AMSS.Services.IService.BackgroundJob
{
    public interface ISendEmailJob 
    {
        [Queue(QueueName.SendEmailJob)]
        Task InvokeAsync(MailRequest request);
    }
}
