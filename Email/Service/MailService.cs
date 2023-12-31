using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using Microsoft.EntityFrameworkCore;
using Email.Data;
using Email.Models.Dtos;


namespace EmailService.Service
{
    public class EmailsService
    {
        private readonly string _email;
        private readonly string _password;
        private readonly IConfiguration _configuration;
        private DbContextOptions<ApplicationDbContext> options;

        public EmailsService(IConfiguration configuration)
        {
            _configuration = configuration;
            _email = _configuration.GetValue<string>("EmailSettings:Email");
            _password = _configuration.GetValue<string>("EmailSettings:Password");
        }

        public EmailsService(DbContextOptions<ApplicationDbContext> options)
        {
            this.options = options;
        }

        public async Task sendEmail(UserMessageDto user, string Message, string? subject = "Thanks for shopping at Ecomm!")
        {
            MimeMessage message1 = new MimeMessage();

            message1.From.Add(new MailboxAddress("Social ", _email));

            message1.To.Add(new MailboxAddress(user.Name, user.Email));

            message1.Subject = subject;

            var body = new TextPart("html")
            {
                Text = Message.ToString()
            };

            message1.Body = body;


            ///

            var client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);

            client.Authenticate(_email, _password);

            await client.SendAsync(message1);

            await client.DisconnectAsync(true);
        }
    }
}