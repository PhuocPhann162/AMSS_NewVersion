using AMSS.Dto.Requests.Mails;
using AMSS.Infrastructures.Interfaces;
using AMSS.Services.IService.BackgroundJob;
using MailKit.Net.Smtp;
using System.Data;

namespace AMSS.Services.BackgroundJob
{
    public class SendEmailJob(
        ILogger<SendEmailJob> _logger,
        ISmtpService _smtpService
        ) : ISendEmailJob
    {
        public async Task InvokeAsync(MailRequest request)
        {
            _logger.LogInformation("Starting send email process...");

            try
            {
                // Send Email using SendGrid
                var response = await _smtpService.SendEmailAsync(request);

                if (response.StatusCode is SmtpStatusCode.Ok)
                {
                    _logger.LogInformation("Email sent successfully.");
                }

                _logger.LogWarning("Queue end ====> {DatTime}", DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            catch (DBConcurrencyException ex)
            {
                _logger.LogError(ex, "Error occurred while sending email.");
                throw; // Re-throw to ensure Hangfire can retry
            }
        }
    }
}
