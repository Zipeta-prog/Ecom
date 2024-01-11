﻿using Email.Models.Dtos;
using MimeKit;
using System.Net.Mail;

namespace Email.Services
{
    public class MailService
    {
        private readonly string _email;
        private readonly string _password;
        private readonly IConfiguration _configuration;

        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
            _email = _configuration.GetValue<string>("EmailSettings:Email");
            _password = _configuration.GetValue<string>("EmailSettings:Password");
        }

        public async Task sendEmail(UserMessageDto user, string Message, string? subject = "Welcome to The Safaris")
        {
            MimeMessage message1 = new MimeMessage();

            message1.From.Add(new MailboxAddress("Safari ", _email));

            message1.To.Add(new MailboxAddress(user.Name, user.Email));

            message1.Subject = subject;

            var body = new TextPart("html")
            {
                Text = Message.ToString()
            };

            message1.Body = body;


            ///

            //var client = new SmtpClient();
            //client.Connect("smtp.gmail.com", 587, false);

            //client.Authenticate(_email, _password);

            //await client.SendAsync(message1);

            //await client.DisconnectAsync(true);
        }
    }
}
