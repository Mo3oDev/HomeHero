using HomeHero.Data;
using MailKit.Net.Smtp;
using MimeKit;

namespace HomeHero.Services
{
    public class HHeroEmail
    {
        readonly HomeHeroContext _context;
        public HHeroEmail(HomeHeroContext context)
        {
            _context = context;
        }


        public async Task SendEmailAsync(string email, string subject, string message,string toUserName)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("HomeHero", "juanmiguelvasquezmoreno@gmail.com"));
            emailMessage.To.Add(new MailboxAddress(toUserName, email));
            emailMessage.Subject = subject;

            var builder = new BodyBuilder();
            builder.HtmlBody = message;
            emailMessage.Body = builder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 465, true);
                await client.AuthenticateAsync("juanmiguelvasquezmoreno@gmail.com", "hbmxtdubiyneuwkv");
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
    }
}

