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
using Microsoft.AspNetCore.Http.HttpResults;

namespace HomeHero.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHHeroEmail _hheroEmail;
        private readonly ILogger<HomeController> _logger;
        private readonly HomeHeroContext _context;
        private readonly HHeroServices _heroServices;
        public HomeController(ILogger<HomeController> logger, HomeHeroContext context, IHHeroEmail hheroEmail)
        {
            _logger = logger;
            _context = context;
            _heroServices = new HHeroServices(context);
            _hheroEmail = hheroEmail;
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

                var claims = new List<Claim>()
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
            
            ViewData["missindFields"] = _heroServices.getNullProperties(user);
            ViewData["user"] = user;
            ViewData["locationResidence"] = _context.Location.FirstOrDefault(l => l.LocationID == user.LocationResidenceID).City;
            var data = _context.Location.ToList();
            ViewData["modifyProfile"] = modifyProfile;
            ViewBag.LocationData = new SelectList(data, "LocationID", "City");
            List<Contact> contactData = _context.Contact.Where(c => c.UserID == idUser).ToList();
            ViewBag.ContactData = contactData;
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
                User user = _context.User.FirstOrDefault(e => e.Email == email);
                ViewBag.RecoveryM = "Mensaje de recuperación enviado correctamente!";
                await _hheroEmail.SendEmailAsync(email, "Recuperacion de Contraseña - HomeHero", $"<p style=\"color: black;\">Estimado <b>{user.NamesUser}</b>,</p><p style=\"color: black;\">Esperamos que se encuentre bien. Hemos recibido una solicitud de recuperación de cuenta asociada a esta dirección de correo electrónico. Como parte del proceso de recuperación, nos complace proporcionarle el siguiente PIN de recuperación:</p><p style=\"color: black;\"><b>Su PIN de recuperación es el siguiente: {Convert.ToBase64String(user.Password)}</b></p><p style=\"color: black;\">Por favor, utilice este PIN para completar el proceso de recuperación de su cuenta. Le recordamos que no debe compartir su PIN de recuperación con nadie, ya que esto podría comprometer la seguridad de su cuenta.</p><p style=\"color: black;\">Si no ha solicitado un PIN de recuperación o si tiene alguna pregunta, por favor no dude en ponerse en contacto con nuestro equipo de soporte.</p><p style=\"color: black;\">Le agradecemos su confianza en nuestro servicio y nos esforzamos por mantener la seguridad de sus datos.</p><p style=\"color: black;\">Atentamente,</p><p style=\"color: black;\"><b>HomeHero</b></p><p style=\"color: black;\">Equipo de soporte al cliente</p>\r\n", user.NamesUser + " " + user.SurnamesUser);
                ViewBag.ValidateM = false;
                return View("~/Views/HeroViews/RecoverChangePW.cshtml");
            }
            ViewBag.RecoveryM = "No hay resultados de búsqueda!";
            return View("~/Views/HeroViews/RecoverSendCode.cshtml");
        }
        public async Task<IActionResult> ValidateAction([FromForm] string recoverPin, [FromForm] string newPassword, [FromForm] string newPassword2)
        {
            if (string.IsNullOrWhiteSpace(recoverPin))
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
            await _heroServices.HHeroEncrypt.ChangePassword(newPassword,recoverPin);
            ViewBag.Message = "El cambio de contraseña se ha realizado correctamente!";
            return View("~/Views/HeroViews/Login.cshtml");
        }

        public IActionResult addContact([FromForm] double contactNum)
        {
            var claimsPrincipal = HttpContext.User;
            var idUserClaim = claimsPrincipal.FindFirst("IdUsuario");
            int idUser;
            int.TryParse(idUserClaim.Value, out idUser);

            _context.Contact.Add(
                new Contact
                {
                    UserID = idUser,
                    NumPhone = contactNum.ToString()
                }
            );
            _context.SaveChanges();
            return Ok();
        }

        public IActionResult GetContactData()
        {
            var claimsPrincipal = HttpContext.User;
            var idUserClaim = claimsPrincipal.FindFirst("IdUsuario");
            int idUser;
            int.TryParse(idUserClaim.Value, out idUser);
            List<Contact> contactData = _context.Contact.Where(c => c.UserID == idUser).ToList();
            ViewBag.ContactData = contactData;
            return PartialView("~/Views/HeroViews/_ContactData.cshtml", contactData);
        }

        public async Task<IActionResult> removeContact(string[] selectedContacts)
        {
            var claimsPrincipal = HttpContext.User;
            var idUserClaim = claimsPrincipal.FindFirst("IdUsuario");
            int idUser;
            int.TryParse(idUserClaim.Value, out idUser);
            foreach ( var contactSel in selectedContacts)
            {
                Contact contact = _context.Contact.FirstOrDefault(c => c.UserID == idUser && c.NumPhone == contactSel);
                _context.Contact.Remove(contact);
                _context.SaveChanges();
            }
            return Ok();
        }
    }
}