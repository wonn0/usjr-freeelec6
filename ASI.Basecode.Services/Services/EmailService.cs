using ASI.Basecode.Services.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace ASI.Basecode.Services.Services
{
    public class EmailService : IEmailService
    {
        private readonly IMapper _mapper;
        private readonly string _apiKey;
        private readonly ILogger<EmailService> _logger;

        public EmailService(IMapper mapper, IConfiguration configuration, ILogger<EmailService> logger)
        {
            _mapper = mapper;
            _apiKey = configuration["SendGrid:ApiKey"];
            _logger = logger;
        }

        //public async Task SendEmailAsync(string email, string subject, string message)
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            try
            {
                var client = new SendGridClient(_apiKey);
                var from = new EmailAddress("delishm12@gmail.com", "Skooby Admin");
                var to = new EmailAddress(email);
                var plainTextContent = message;
                var htmlContent = message;
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                var response = await client.SendEmailAsync(msg);

                _logger.LogInformation($"Email sent successfully to {email} Response: {response.StatusCode}");
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Failed to send email to {email}", email);
            }
        }
    }
}
