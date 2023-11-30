using System.Threading.Tasks;
using ASI.Basecode.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace ASI.Basecode.Services.Services
{
    public class EmailSender : IEmailSender // Use the correct interface name here
    {
        private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var apiKey = _configuration["SendGridKey"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("no-reply@yourdomain.com", "Your App Name");
            var to = new EmailAddress(email);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, "", htmlMessage);
            await client.SendEmailAsync(msg);
        }
    }
}
