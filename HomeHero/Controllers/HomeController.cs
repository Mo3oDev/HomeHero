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
        private readonly HHeroServices _heroServices;
        public HomeController(ILogger<HomeController> logger, HomeHeroContext context)
        {
            _logger = logger;
            _context = context;
            _heroServices = new HHeroServices(context);
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
            User user = _heroServices.HHeroEncrypt.LogInUser(email, password);
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

            bool registered = await _heroServices.HHeroEncrypt.AddUser(name, surnames, int.Parse(location), email, password);
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
        //Password Recovery Functions
        public IActionResult RecoverSendCode()
        {
            return View("~/Views/HeroViews/RecoverSendCode.cshtml");
        }

        public async Task<IActionResult> RecoverSendCodeAction([FromForm] string email)
        {
            if (_heroServices.HHeroEncrypt.ExistEmail(email))
            {
                ViewBag.RecoveryM = "Mensaje de recuperación enviado correctamente!";
                await _heroServices.HHeroEmail.SendEmailAsync("juanmiguelvasquezmoreno@gmail.com", "Recuperacion de Contraseña - HomeHero","asb","Yami");
                ViewBag.ValidateM = false;
                return View("~/Views/HeroViews/RecoverChangePW.cshtml");
            }
            ViewBag.RecoveryM = "No hay resultados de búsqueda!";
            return View("~/Views/HeroViews/RecoverSendCode.cshtml");
        }
        public IActionResult ValidateAction([FromForm] string recoverPin,[FromForm] string newPassword, [FromForm] string newPassword2)
        {
            if (string.IsNullOrWhiteSpace(recoverPin))
            {
                ViewBag.ValidateM = false;
                ViewBag.ValidateMessage = "El pin es incorrecto!";
                return View("~/Views/HeroViews/RecoverChangePW.cshtml");
            }
            if (_heroServices.HHeroEncrypt.SaltIsCorrect(recoverPin) == null)
            {
                ViewBag.ValidateM = false;
                ViewBag.ValidateMessage = "El pin es incorrecto!";
                return View("~/Views/HeroViews/RecoverChangePW.cshtml");
            }
            if (string.IsNullOrWhiteSpace(newPassword) || string.IsNullOrWhiteSpace(newPassword2))
            {
                ViewBag.ValidateM = false;
                ViewBag.ValidateMessage = "Debe llenar los campos!";
                return View("~/Views/HeroViews/RecoverChangePW.cshtml");
            }
            if (newPassword2 != newPassword)
            {
                ViewBag.ValidateM = false;
                ViewBag.ValidateMessage = "Las contraseñas deben coincidir!";
                return View("~/Views/HeroViews/RecoverChangePW.cshtml");
            }
            ViewBag.ValidateM = true;
            _heroServices.HHeroEncrypt.ChangePassword(_heroServices.HHeroEncrypt.SaltIsCorrect(recoverPin).UserId, newPassword);
            ViewBag.Message = "El cambio de contraseña se ha realizado correctamente!";
            return View("~/Views/HeroViews/Login.cshtml");
        }

    }
}