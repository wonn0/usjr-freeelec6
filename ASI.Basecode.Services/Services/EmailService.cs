using ASI.Basecode.Services.Interfaces;
using ASI.Basecode.Services.Models;
using ASI.Basecode.WebApp.Services;
using AutoMapper;
using Data.Interfaces;
using Data.Models;
using SendGrid;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ASI.Basecode.Services.Services
{
    public class EmailService : IEmailService
    {
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;
        private readonly string _apiKey;
        public EmailService(IEmailService emailService, IMapper mapper)
        {
            _emailService = emailService;
            _mapper = mapper;
            _apiKey = "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";
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var client = new SendGridClient(_apiKey);
            var from = new SendGrid.Helpers.Mail.EmailAddress("delishm12@gmail.com", "Skooby Admin");
            var to = new SendGrid.Helpers.Mail.EmailAddress(email);
            var plainTextContent = message;
            var htmlContent = message;
            var msg = SendGrid.Helpers.Mail.MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
