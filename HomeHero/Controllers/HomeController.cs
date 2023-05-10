using HomeHero.Data;
using HomeHero.Models;
using HomeHero.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;
using HomeHero.Filters;
using System.Text;

namespace HomeHero.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HomeHeroContext _context;

        public HomeController(ILogger<HomeController> logger, HomeHeroContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return RedirectToAction("PrincipalMb", "Home");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult LogIn()
        {

            return View("~/Views/HeroViews/Login.cshtml");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogInAction([FromForm] string email, [FromForm] string password)
        {
            HomeHeroServices heroServices = new HomeHeroServices(_context);
            User user = heroServices.LogInUser(email, password);
           
            if (user == null)
            {
                ViewData["message"] = "Datos invalidos!";
                return View("~/Views/HeroViews/Login.cshtml");
            }
            else
            {
                ClaimsIdentity identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.NamesUser),
                    new Claim(ClaimTypes.Role, _context.Role.FirstOrDefault(e => e.RoleID == user.RoleID).NameRole),
                    new Claim("IdUsuario", user.UserId.ToString()),
                    new Claim("EmailUsuario", user.Email),
                    new Claim("Qualification",user.QualificationUser.ToString()),
                    new Claim(ClaimTypes.Surname,user.SurnamesUser),
                    new Claim("LocationRecidence",user.LocationResidenceID.ToString()),
                    new Claim("Curriculum", Convert.ToBase64String(user.Curriculum)),
                    new Claim("VolunteerPermises",user.VolunteerPermises.ToString()),
                    new Claim("sexUser",user.SexUser.ToString()),
                };

                identity.AddClaim(claims.FirstOrDefault(c => c.Type == ClaimTypes.Name));
                identity.AddClaim(claims.FirstOrDefault(c => c.Type == ClaimTypes.Role));
                identity.AddClaim(claims.FirstOrDefault(c => c.Type == "IdUsuario"));
                identity.AddClaim(claims.FirstOrDefault(c => c.Type == "EmailUsuario"));

                ClaimsPrincipal userPrincipal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal, new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.Now.AddMinutes(45)
                });
                
                return RedirectToAction("PrincipalMb", "Home");
            }
        }

        public IActionResult PrincipalMb()
        {
            return View("~/Views/HeroViews/Principal.cshtml");
        }
        public IActionResult OfferHelp()
        {
            return View("~/Views/HeroViews/OfferHelp.cshtml");
        }
        public IActionResult ProfileMb()
        {
            var claimsPrincipal = HttpContext.User;
            var roleName = claimsPrincipal.FindFirstValue(ClaimTypes.Role);
            User user = new User
            {
                UserId = Convert.ToInt32(claimsPrincipal.FindFirstValue("IdUsuario")),
                NamesUser = claimsPrincipal.FindFirstValue(ClaimTypes.Name),
                SurnamesUser = claimsPrincipal.FindFirstValue(ClaimTypes.Surname),
                RoleID = _context.Role.FirstOrDefault(e => e.NameRole == roleName).RoleID,
                Email = claimsPrincipal.FindFirstValue("EmailUsuario"),
                SexUser = claimsPrincipal.FindFirstValue("sexUser")[0],
                QualificationUser = Convert.ToInt32(claimsPrincipal.FindFirstValue("Qualification")),
                VolunteerPermises = Convert.ToBoolean(claimsPrincipal.FindFirstValue("VolunteerPermises")),
                Curriculum = Encoding.UTF8.GetBytes(claimsPrincipal.FindFirstValue("Curriculum")),
                LocationResidenceID = Convert.ToInt32(claimsPrincipal.FindFirstValue("LocationRecidence"))
            };
            
            ViewData["missindFields"] = 0;
            ViewData["user"] = user;
            return View("~/Views/HeroViews/profileMb.cshtml");
        }

        public IActionResult AksHelp()
        {
            var data = _context.Location.ToList();
            ViewBag.LocationData = new SelectList(data, "LocationID", "City");
            return View("~/Views/HeroViews/AskHelp.cshtml");
            
        }

        public IActionResult RecoverSendCode()
        {
            return View("~/Views/HeroViews/RecoverSendCode.cshtml");
        }
        public IActionResult RecoverSendCodeAction(string email, int recoverPin)
        {
            return View("~/Views/HeroViews/RecoverChangePW.cshtml");
        }
        public IActionResult SignUp()
        {
            var data = _context.Location.ToList();
            ViewBag.LocationData = new SelectList(data, "LocationID", "City");
            return View("~/Views/HeroViews/SignUp.cshtml");
        }
        public IActionResult Solicitudes()
        {
            return View("~/Views/HeroViews/SearchRequest.cshtml");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUpAction([FromForm] string name, [FromForm] string surnames, [FromForm] string location, [FromForm] string email, [FromForm] string password)
        {
            HomeHeroServices heroServices = new HomeHeroServices(_context);
            bool registered = await heroServices.AddUser(name, surnames, int.Parse(location), email, password);
            if (registered)
                ViewBag.Message = "¡Usuario registrado con exito!";
            else
            {
                ViewBag.Message = "¡El usuario ya existe!";
                return View("~/Views/HeroViews/Login.cshtml");
            }

            return View("~/Views/HeroViews/Login.cshtml");
        }

        public IActionResult AccessError()
        {
            ViewBag.Message = "Error de acceso";
            return View("~/Views/Manage/AccessError.cshtml");
        }

        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
        [AuthorizeUsers]
        public IActionResult ProtectedPage()
        {
            return View("~/Views/HeroViews/ProtectedPage.cshtml");
        }

    }
}