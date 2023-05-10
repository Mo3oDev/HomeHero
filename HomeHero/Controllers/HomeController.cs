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

                Claim claimUserName = new(ClaimTypes.Name, user.NamesUser);
                Claim claimRole = new(ClaimTypes.Role, _context.Role.FirstOrDefault(e => e.RoleID == user.RoleID).NameRole);
                Claim claimIdUsuario = new("IdUsuario", user.UserId.ToString());
                Claim claimEmail = new("EmailUsuario", user.Email);

                identity.AddClaim(claimUserName);
                identity.AddClaim(claimRole);
                identity.AddClaim(claimIdUsuario);
                identity.AddClaim(claimEmail);

                ClaimsPrincipal userPrincipal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal, new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.Now.AddMinutes(45)
                });
                ViewData["user"] = user;
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