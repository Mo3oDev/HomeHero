namespace HomeHero.Services
{
    public interface IHHeroEmail
    {
        Task SendEmailAsync(string email, string subject, string message,string toName);
    }
}
