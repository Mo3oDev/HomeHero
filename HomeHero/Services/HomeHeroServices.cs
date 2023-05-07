using HomeHero.Data;
using System.Security.Cryptography;
using System.Text;
using HomeHero.Models;
namespace HomeHero.Services
{
    public class HomeHeroServices
    {
        readonly HomeHeroContext _context;
        public HomeHeroServices(HomeHeroContext context)
        {
            _context = context;
        }

        public async Task AddUser(string name, string surname, int location, string email, string password)
        {
            _context.Users.Add(new User
            {
                NamesUser = name,
                SurnamesUser = surname,
                LocationResidenceID = location,
                Email = email,
                Password = Encrypt(password)
            }); ;
            await _context.SaveChangesAsync();
        }
        public string Encrypt(string rawData)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
            var builder = new StringBuilder();
            foreach (var b in bytes) builder.Append(b.ToString("x2"));
            return builder.ToString();
        }
    }
}
