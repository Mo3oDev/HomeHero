using HomeHero.Data;
using HomeHero.Filters;
using HomeHero.Models;
using HomeHero.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;
using HomeHero.Filters;
using System.Text;
using Microsoft.IdentityModel.Tokens;

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

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.NamesUser),
                    new Claim(ClaimTypes.Role, _context.Role.FirstOrDefault(e => e.RoleID == user.RoleID).NameRole),
                    new Claim("IdUsuario", user.UserId.ToString()),
                    new Claim("EmailUsuario", user.Email),
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
        public IActionResult ProfileMb(bool modifyProfile = false)
        {
            var claimsPrincipal = HttpContext.User;

            var idUserClaim = claimsPrincipal.FindFirst("IdUsuario");
            int idUser;
            int.TryParse(idUserClaim.Value, out idUser);

            User user = _context.User.FirstOrDefault(u => u.UserId == idUser);
            
            ViewData["missindFields"] = heroServices.getNullProperties(user);
            ViewData["user"] = user;
            ViewData["locationResidence"] = _context.Location.FirstOrDefault(l => l.LocationID == user.LocationResidenceID).City;
            var data = _context.Location.ToList();
            ViewData["modifyProfile"] = modifyProfile;
            ViewBag.LocationData = new SelectList(data, "LocationID", "City");
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