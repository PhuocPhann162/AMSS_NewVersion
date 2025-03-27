using AMSS.Dto.Requests.Mails;
using AMSS.Infrastructures.Configurations;
using AMSS.Infrastructures.Interfaces;
using MailKit.Net.Smtp;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Options;
using MimeKit;
using RazorLight;

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

            var emailContent = await RenderTemplateAsync(mailRequest.TemplateName, mailRequest);

            var message = new MimeMessage();

            message.From.Add(new MailboxAddress(_mailConfiguration.SenderName, _mailConfiguration.SenderEmail));
            message.To.Add(new MailboxAddress(mailRequest.Tos.First().Name, mailRequest.Tos.First().Email));
            message.Subject = mailRequest.Subject;

            message.Body = new TextPart("html")
            {
                Text = emailContent
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

        private async Task<string> RenderTemplateAsync<T>(string templateName, T model)
        {
            var templateDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "EmailTemplate");

            var engine = new RazorLightEngineBuilder()
               .UseFileSystemProject(templateDir)
               .UseMemoryCachingProvider()
               .Build();

            var templatePath = Path.Combine(templateDir, $"{templateName}.cshtml");

            if (!File.Exists(templatePath))
            {
                throw new FileNotFoundException($"Template not found: {templatePath}");
            }


            return await engine.CompileRenderAsync($"{templateName}.cshtml", model);
        }
    }
}
