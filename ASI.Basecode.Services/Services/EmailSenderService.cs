using System;
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
            try
            {
                var apiKey = _configuration["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"]; // Make sure this key is stored in your configuration file or as an environment variable
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress("garfield.lim@usjr.edu.ph", "Skooby");
                var to = new EmailAddress(email);
                var msg = MailHelper.CreateSingleEmail(from, to, subject, "", htmlMessage);
                var response = await client.SendEmailAsync(msg);

                // Optionally, inspect the response.
                if (!response.IsSuccessStatusCode)
                {
                    // Log the response body or handle the error
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                // You might also want to throw the exception or handle it according to your application's needs.
            }
        }
    }
}
