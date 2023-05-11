using HomeHero.Data;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;

namespace HomeHero.Services
{
    public class HHeroEmail : IHHeroEmail
    {
        private readonly string _gmailUsername;
        private readonly string _gmailPassword;

        public HHeroEmail(string gmailUsername, string gmailPassword)
        {
            _gmailUsername = gmailUsername;
            _gmailPassword = gmailPassword;
        }


        public async Task SendEmailAsync(string email, string subject, string message, string toName)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Administrador", _gmailUsername));
            emailMessage.To.Add(new MailboxAddress(toName, email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(TextFormat.Html)
            {
                Text = message
            };

            using var client = new SmtpClient();
            await client.ConnectAsync("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
            await client.AuthenticateAsync(_gmailUsername, _gmailPassword);
            await client.SendAsync(emailMessage);
            await client.DisconnectAsync(true);
        }
    }
}

