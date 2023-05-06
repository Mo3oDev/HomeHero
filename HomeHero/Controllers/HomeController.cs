using HomeHero.Data;
using HomeHero.Models;
using HomeHero.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

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
            return View();
        }

        public IActionResult Privacy()
        {
            return View(); 
        }
        public IActionResult LogIn()
        {
   
            return View("~/Views/HeroViews/Login.cshtml");
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
            var data = _context.Locations.ToList();
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
        public async Task<IActionResult> SignUpAction([FromForm] string name , [FromForm] string surnames, [FromForm] string location, [FromForm] string email, [FromForm] string password)
        {
            HomeHeroServices heroServices = new HomeHeroServices(_context);
            await heroServices.AddUser(name, surnames,int.Parse(location),email, password);
            return View("~/Views/HeroViews/Login.cshtml");
        }
    }
}