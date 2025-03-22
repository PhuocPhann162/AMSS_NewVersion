using AMSS.Dto.Requests.Mails;
using AMSS.Infrastructures.Configurations;
using AMSS.Infrastructures.Interfaces;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace AMSS.Infrastructures.Services
{
    public class SmtpService : ISmtpService
    {
        private readonly SmtpConfiguration _mailConfiguration;
        private readonly ILogger<SmtpService> _logger;
        public SmtpService(ILogger<SmtpService> logger, IOptionsMonitor<SmtpConfiguration> mailConfiguration)
        {
            _logger = logger;
            _mailConfiguration = mailConfiguration.CurrentValue;
        }

        public async Task<SmtpResponse> SendEmailAsync(MailRequest mailRequest)
        {
            _logger.LogInformation("Start send email process...");
            var message = new MimeMessage();

            message.From.Add(new MailboxAddress(_mailConfiguration.SenderName, _mailConfiguration.SenderEmail));
            message.To.Add(new MailboxAddress(mailRequest.Tos.First().Name, mailRequest.Tos.First().Email));
            message.Subject = mailRequest.Subject;

            message.Body = new TextPart("html")
            {
                Text = mailRequest.Content
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_mailConfiguration.Host, _mailConfiguration.Port, MailKit.Security.SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(_mailConfiguration.Username, _mailConfiguration.Password);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
            _logger.LogInformation("Email sent successfully!");

            return new SmtpResponse(SmtpStatusCode.Ok, "Successfully");
        }
    }
}
