using HomeHero.Data;
using HomeHero.Filters;
using HomeHero.Models;
using HomeHero.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Diagnostics;
using System.Security.Claims;

namespace HomeHero.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHHeroEmail _hheroEmail;
        private readonly ILogger<HomeController> _logger;
        private readonly HomeHeroContext _context;
        private readonly HHeroServices _heroServices;
        private readonly IWebHostEnvironment _hostEnvironment;
        public HomeController(ILogger<HomeController> logger, HomeHeroContext context, IHHeroEmail hheroEmail, IWebHostEnvironment hostEnvironment)
        {
            _logger = logger;
            _context = context;
            _heroServices = new HHeroServices(context);
            _hheroEmail = hheroEmail;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View("~/Views/HeroViews/Login.cshtml");
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
                    new Claim(ClaimTypes.Role, _context.Role.FirstOrDefault(e => e.RoleID == user.RoleID_User).NameRole),
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
        [AuthorizeUsers]
        public IActionResult PrincipalMb()
        {
            return View("~/Views/HeroViews/Principal.cshtml");
        }
        [AuthorizeUsers]
        public IActionResult ManageRequest(int activeTab = 1)
        {
            var claimsPrincipal = HttpContext.User;
            var idUserClaim = claimsPrincipal.FindFirst("IdUsuario");
            int idUser;
            int.TryParse(idUserClaim.Value, out idUser);
            ViewBag.active = activeTab;
            if (activeTab == 1)
            {
                ViewBag.Requests = _context.Request.Where(e => e.ReqStateID_Request == 1 && e.UserId_Request == idUser).ToList();

            }
            else if (activeTab == 2)
            {

                ViewBag.Requests = _context.Request.Where(e => e.ReqStateID_Request == 2 && e.UserId_Request == idUser).ToList();

            }
            else if (activeTab == 3)
            {
                ViewBag.Requests = _context.Request.Where(e => e.ReqStateID_Request == 3 && e.UserId_Request == idUser).ToList();

            }

            _context.Request.Include(r => r.Location_Request).ToList();
            return View("~/Views/HeroViews/ManageRequest.cshtml");
        }

        public IActionResult ManageRequest2(int RequestID, int activeTab)
        {
            var claimsPrincipal = HttpContext.User;
            var idUserClaim = claimsPrincipal.FindFirst("IdUsuario");
            int idUser;
            int.TryParse(idUserClaim.Value, out idUser);
            ViewBag.active = activeTab;


            if (activeTab == 1)
            {
                ViewBag.RequestData = _context.AttentionRequest.Where(e => e.RequestID_AttentionRequest == RequestID && e.AttentionRequest_StateID == 1).ToList();
                _context.AttentionRequest.Include(r => r.HelperUser).ToList();
                ViewBag.Requests = _context.Request.Where(e => e.ReqStateID_Request == 1 && e.UserId_Request == idUser).ToList();
                ViewBag.Request = _context.Request.FirstOrDefault(r => r.RequestID == RequestID);
                _context.Request.Include(r => r.Location_Request).ToList();

            }
            else if (activeTab == 2)
            {
                ViewBag.RequestData = _context.AttentionRequest.Where(e => e.RequestID_AttentionRequest == RequestID && e.AttentionRequest_StateID == 2).ToList();
                _context.AttentionRequest.Include(r => r.HelperUser).ToList();
                ViewBag.Requests = _context.Request.Where(e => e.ReqStateID_Request == 2 && e.UserId_Request == idUser).ToList();
                ViewBag.Request = _context.Request.FirstOrDefault(r => r.RequestID == RequestID);
                _context.Request.Include(r => r.Location_Request).ToList();


            }
            else if (activeTab == 3)
            {
                ViewBag.RequestData = _context.AttentionRequest.Where(e => e.RequestID_AttentionRequest == RequestID && e.AttentionRequest_StateID == 3).ToList();
                _context.AttentionRequest.Include(r => r.HelperUser).ToList();
                ViewBag.Requests = _context.Request.Where(e => e.ReqStateID_Request == 3 && e.UserId_Request == idUser).ToList();
                ViewBag.Request = _context.Request.FirstOrDefault(r => r.RequestID == RequestID);
                _context.Request.Include(r => r.Location_Request).ToList();

            }

            return View("~/Views/HeroViews/ManageRequest2.cshtml");
        }
        [AuthorizeUsers]
        public IActionResult ProfileMb(bool modifyProfile = false)
        {
            ViewData["modifyProfile"] = modifyProfile;
            ViewBag.PublicProfile = false;
            var claimsPrincipal = HttpContext.User;
            var idUserClaim = claimsPrincipal.FindFirst("IdUsuario");
            int idUser;
            int.TryParse(idUserClaim.Value, out idUser);
            User user = _context.User.FirstOrDefault(u => u.UserId == idUser);
            ViewData["missindFields"] = _heroServices.getNullProperties(user);
            ViewData["user"] = user;
            ViewData["locationResidence"] = _context.Location.FirstOrDefault(l => l.LocationID == user.LocationResidenceID).City;
            ViewData["Sexs"] = new List<string> { "Masculino", "Femenino", "No binario", "Prefiero no responder" };
            ViewData["CurrentSex"] = GetSexUserValue(user.SexUser);
            var data = _context.Location.ToList();
            ViewBag.LocationData = new SelectList(data, "LocationID", "City");
            List<Contact> contactData = _context.Contact.Where(c => c.UserID_Contact == idUser).ToList();
            ViewBag.ContactData = contactData;
            return View("~/Views/HeroViews/profileMb.cshtml");
        }
        [AuthorizeUsers]
        public IActionResult VisitProfile(int idUser)
        {
            ViewData["modifyProfile"] = false;
            ViewBag.PublicProfile = true;
            User user = _context.User.FirstOrDefault(u => u.UserId == idUser);
            ViewData["missindFields"] = _heroServices.getNullProperties(user);
            ViewData["user"] = user;
            ViewData["locationResidence"] = _context.Location.FirstOrDefault(l => l.LocationID == user.LocationResidenceID).City;
            ViewData["Sexs"] = new List<string> { "Masculino", "Femenino", "No binario", "Prefiero no responder" };
            ViewData["CurrentSex"] = GetSexUserValue(user.SexUser);
            var data = _context.Location.ToList();
            ViewBag.LocationData = new SelectList(data, "LocationID", "City");
            List<Contact> contactData = _context.Contact.Where(c => c.UserID_Contact == idUser).ToList();
            ViewBag.ContactData = contactData;
            return View("~/Views/HeroViews/profileMb.cshtml");
        }
        [AuthorizeUsers]
        public IActionResult AskHelp()
        {
            var data = _context.Location.ToList();
            ViewBag.LocationData = new SelectList(data, "LocationID", "City");
            return View("~/Views/HeroViews/AskHelp.cshtml");

        }
        [AuthorizeUsers]
        [HttpPost]
        public async Task<IActionResult> AddRequest([FromForm] string title, [FromForm] string desc,
            [FromForm] IFormFile image, [FromForm] string location,
            [FromForm] DateTime dateReq, [FromForm] int cantMb)
        {

            if (image == null || image.Length == 0)
            {
                ViewBag.ErrorMessage = "Selecciona un archivo de imagen";
                return RedirectToAction("AskHelp");
            }
            var claimsPrincipal = HttpContext.User;
            var idUserClaim = claimsPrincipal.FindFirst("IdUsuario");
            int idUser;
            int.TryParse(idUserClaim.Value, out idUser);
            await _heroServices.HHeroRequest.AddRequest(title, desc, image, location, dateReq, cantMb, idUser);
            ViewBag.Message = "La petición se ha generado correctamente";
            return View("~/Views/HeroViews/Principal.cshtml");
        }
        public IActionResult SignUp()
        {
            var data = _context.Location.ToList();
            ViewBag.LocationData = new SelectList(data, "LocationID", "City");
            return View("~/Views/HeroViews/SignUp.cshtml");
        }
        [AuthorizeUsers]
        public IActionResult RequestList()
        {
            var claimsPrincipal = HttpContext.User;
            var idUserClaim = claimsPrincipal.FindFirst("IdUsuario");
            int idUser;
            int.TryParse(idUserClaim.Value, out idUser);
            ViewBag.Requests = _context.Request.Where(e => e.UserId_Request != idUser && e.ReqStateID_Request == 1).ToList();
            ViewBag.LocationData = _context.Request.Include(r => r.Location_Request).ToList();
            ViewBag.RequestSelected = _context.Request.FirstOrDefault();
            return View("~/Views/HeroViews/RequestList.cshtml");
        }
        [AuthorizeUsers]
        public IActionResult FilterAction(string titleFilter, string cityFilter, DateTime? dateFilter)
        {
            var requests = _context.Request.AsQueryable();

            if (!string.IsNullOrEmpty(titleFilter))
            {
                requests = requests.Where(r => r.RequestTitle.Contains(titleFilter));
            }

            if (!string.IsNullOrEmpty(cityFilter))
            {
                requests = requests.Where(r => r.Location_Request.City.Contains(cityFilter));
            }

            if (dateFilter.HasValue)
            {
                requests = requests.Where(r => r.PublicationReqDate.Date == dateFilter.Value.Date);
            }
            requests = requests.Include(r => r.Location_Request);
            var claimsPrincipal = HttpContext.User;
            var idUserClaim = claimsPrincipal.FindFirst("IdUsuario");
            int idUser;
            int.TryParse(idUserClaim.Value, out idUser);
            ViewBag.Requests = _context.Request.Where(e => e.UserId_Request != idUser && e.ReqStateID_Request == 1).ToList();
            ViewBag.LocationData = _context.Request.Include(r => r.Location_Request).ToList();
            return View("~/Views/HeroViews/RequestList.cshtml");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId2 = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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
        [AuthorizeUsers]
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
            await _heroServices.HHeroEncrypt.ChangePassword(newPassword, recoverPin);
            ViewBag.Message = "El cambio de contraseña se ha realizado correctamente!";
            return View("~/Views/HeroViews/Login.cshtml");
        }


        [AuthorizeUsers]
        public IActionResult addContact([FromForm] double contactNum)
        {
            var claimsPrincipal = HttpContext.User;
            var idUserClaim = claimsPrincipal.FindFirst("IdUsuario");
            int idUser;
            int.TryParse(idUserClaim.Value, out idUser);

            _context.Contact.Add(
                new Contact
                {
                    UserID_Contact = idUser,
                    NumPhone = contactNum.ToString()
                }
            );
            _context.SaveChanges();
            return Ok();
        }
        [AuthorizeUsers]
        public IActionResult GetContactData()
        {
            var claimsPrincipal = HttpContext.User;
            var idUserClaim = claimsPrincipal.FindFirst("IdUsuario");
            int idUser;
            int.TryParse(idUserClaim.Value, out idUser);
            List<Contact> contactData = _context.Contact.Where(c => c.UserID_Contact == idUser).ToList();
            ViewBag.ContactData = contactData;
            return PartialView("~/Views/HeroViews/_ContactData.cshtml", contactData);
        }
        [AuthorizeUsers]
        public async Task<IActionResult> removeContact(string[] selectedContacts)
        {
            var claimsPrincipal = HttpContext.User;
            var idUserClaim = claimsPrincipal.FindFirst("IdUsuario");
            int idUser;
            int.TryParse(idUserClaim.Value, out idUser);
            foreach (var contactSel in selectedContacts)
            {
                Contact contact = _context.Contact.FirstOrDefault(c => c.UserID_Contact == idUser && c.NumPhone == contactSel);
                _context.Contact.Remove(contact);
                _context.SaveChanges();
            }
            return Ok();
        }
        [AuthorizeUsers]
        public async Task<IActionResult> updateProfile([FromForm] string name, [FromForm] string surnames,
            [FromForm] string email, [FromForm] int idReal, [FromForm] int location,
            [FromForm] int sex, [FromForm] IFormFile curriculum, [FromForm] IFormFile image)
        {
            var claimsPrincipal = HttpContext.User;
            var idUserClaim = claimsPrincipal.FindFirst("IdUsuario");
            int idUser;
            int.TryParse(idUserClaim.Value, out idUser);
            var user = _context.User.Find(idUser);
            user.NamesUser = name;
            user.SurnamesUser = surnames;
            if (curriculum != null)
            {
                user.Curriculum = ConvertToByteArrayAsync(curriculum);
            }
            if (image != null)
            {
                user.ProfilePicture = ConvertToByteArrayAsync(image);
            }
            user.Email = email;
            if (idReal > 1) user.RealUserID = idReal.ToString();
            user.LocationResidenceID = location;
            user.SexUser = GetSexUser(sex);
            _context.SaveChanges();
            return RedirectToAction("ProfileMb", "Home");
        }
        public byte[] ConvertToByteArrayAsync(IFormFile file)
        {
            if (file == null) return null;

            using var ms = new MemoryStream();
            file.CopyTo(ms);
            return ms.ToArray();
        }

        private char? GetSexUser(int sex)
        {
            if (sex == 1) return 'M';
            else if (sex == 2) return 'F';
            else if (sex == 3) return '?';
            else return '-';
        }

        private int GetSexUserValue(char? sex)
        {
            if (sex == 'M') return 1;
            else if (sex == 'F') return 2;
            else if (sex == '?') return 3;
            else return 4;
        }

        private FileResult ConvertToPdfFile(byte[] byteArray, ref string fileName)
        {
            MemoryStream ms = new MemoryStream(byteArray);
            return File(ms, "application/pdf", fileName);
        }
        [AuthorizeUsers]
        public async Task<IActionResult> ViewCurriculum(int userId)
        {
            var user = await _context.User.FindAsync(userId);
            if (user == null || user.Curriculum == null)
            {
                return NotFound();
            }

            return File(user.Curriculum, "application/pdf");
        }
        [AuthorizeUsers]
        [HttpPost]
        public IActionResult ReloadModal(int request)
        {
            Request req = _context.Request.FirstOrDefault(r => r.RequestID == request);
            ViewBag.RequestSelected = req;
            ViewBag.Location = _context.Location.FirstOrDefault(l => l.LocationID == req.LocationServiceID).City;
            return PartialView("~/Views/HeroViews/_RequestComplete.cshtml", ViewBag.RequestSelected);
        }
        [AuthorizeUsers]
        [HttpPost]
        public async Task<IActionResult> AddPostulation([FromForm] int request, [FromForm] int price)
        {
            var claimsPrincipal = HttpContext.User;
            var idUserClaim = claimsPrincipal.FindFirst("IdUsuario");
            int idUser;
            int.TryParse(idUserClaim.Value, out idUser);
            if (await _heroServices.HHeroPostulation.AddPostulation(request, price, idUser))
            {
                ViewBag.Message = "Postulación realizada correctamente!";
                ViewBag.Requests = _context.Request.Where(e => e.UserId_Request != idUser && e.ReqStateID_Request == 1).ToList();
                ViewBag.LocationData = _context.Request.Include(r => r.Location_Request).ToList();
                ViewBag.RequestSelected = _context.Request.FirstOrDefault();
                return View("~/Views/HeroViews/RequestList.cshtml");
            }

            ViewBag.Message = "Ya es postulante a esta solicitud, seleccione otra!";
            ViewBag.Requests = _context.Request.ToList();
            ViewBag.LocationData = _context.Request.Include(r => r.Location_Request).ToList();
            ViewBag.RequestSelected = _context.Request.FirstOrDefault();
            return View("~/Views/HeroViews/RequestList.cshtml");
        }
        public async Task<IActionResult> AcceptPostulation(int idUser, int idAttentionRequest)
        {
            if (_context.AttentionRequest.FirstOrDefault(e => e.HelperUser.UserId == idUser && e.RequestID_AttentionRequest == idAttentionRequest && e.AttentionRequest_StateID !=1) == null)
            {
                if (await actualHeroes(idAttentionRequest) < _context.Request.FirstOrDefault(e => e.RequestID == idAttentionRequest).MembersNeeded)
                {
                    AttentionRequest attention = _context.AttentionRequest.FirstOrDefault(e => e.HelperUser.UserId == idUser && e.RequestID_AttentionRequest == idAttentionRequest);
                    attention.AttentionRequest_StateID = 2;
                    _context.AttentionRequest.Update(attention);
                    await _context.SaveChangesAsync();
                }
                if (await actualHeroes(idAttentionRequest) == _context.Request.FirstOrDefault(e => e.RequestID == idAttentionRequest).MembersNeeded)
                {
                    Request request = _context.Request.Find(idAttentionRequest);
                    request.ReqStateID_Request = 2;
                    _context.Request.Update(request);
                    await _context.SaveChangesAsync();
                }
            }


            return RedirectToAction("ManageRequest");
        }
        public async Task<IActionResult> RejectPostulation(int idUser, int idAttentionRequest)
        {
            AttentionRequest attention = _context.AttentionRequest.FirstOrDefault(e => e.HelperUser.UserId == idUser && e.RequestID_AttentionRequest == idAttentionRequest);
            _context.AttentionRequest.Remove(attention);
            await _context.SaveChangesAsync();
            return RedirectToAction("ManageRequest");
        }
        public async Task<int> actualHeroes(int idAttentionRequest)
        {
            return _context.AttentionRequest.Where(e => e.RequestID_AttentionRequest == idAttentionRequest && e.AttentionRequest_StateID !=1).ToList().Count();
        }
        public async Task<IActionResult> EvaluateHero(int idUser, int idAttentionRequest)
        {
            if (_context.AttentionRequest.FirstOrDefault(e => e.HelperUser.UserId == idUser && e.RequestID_AttentionRequest == idAttentionRequest && e.AttentionRequest_StateID != 2) == null)
            {
                if (await actualHeroes(idAttentionRequest) < _context.Request.FirstOrDefault(e => e.RequestID == idAttentionRequest).MembersNeeded)
                {
                    AttentionRequest attention = _context.AttentionRequest.FirstOrDefault(e => e.HelperUser.UserId == idUser && e.RequestID_AttentionRequest == idAttentionRequest);
                    attention.AttentionRequest_StateID = 3;
                    _context.AttentionRequest.Update(attention);
                    await _context.SaveChangesAsync();
                }
                if (await actualHeroes(idAttentionRequest) == _context.Request.FirstOrDefault(e => e.RequestID == idAttentionRequest).MembersNeeded)
                {
                    Request request = _context.Request.Find(idAttentionRequest);
                    request.ReqStateID_Request = 3;
                    _context.Request.Update(request);
                    await _context.SaveChangesAsync();
                }
            }
            return RedirectToAction("ManageRequest");
        }
    }
}