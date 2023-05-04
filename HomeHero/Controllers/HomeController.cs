using HomeHero.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HomeHero.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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

        public IActionResult LogInAction(string password,string email)
        {
            return View("~/Views/HeroViews/Principal.cshtml");
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
    }
}