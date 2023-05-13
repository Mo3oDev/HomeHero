using HomeHero.Data;
using HomeHero.Models;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
namespace HomeHero.Services
{
    public class HHeroServices
    {

        readonly HomeHeroContext _context;
        public HHeroEncrypt HHeroEncrypt;
        public HHeroEmail HHeroEmail;
        public HHeroRequest HHeroRequest;
        public HHeroPostulation HHeroPostulation;
        public HHeroServices(HomeHeroContext context)
        {
            _context = context;
            HHeroEncrypt = new HHeroEncrypt(context);
            HHeroRequest = new HHeroRequest(context);
            HHeroPostulation = new HHeroPostulation(context);
        }
        public int getNullProperties(User user)
        {
            int nullProperties = 0;
            if (user.RealUserID == null) nullProperties++;
            if (user.SexUser == null) nullProperties++;
            if (user.Curriculum == null) nullProperties++;

            return nullProperties;
        }

    }
}
