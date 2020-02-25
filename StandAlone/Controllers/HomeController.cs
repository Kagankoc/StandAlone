using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StandAlone.Infrastructure;
using StandAlone.Models;
using System;
using System.Diagnostics;

namespace StandAlone.Controllers
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

        [ChangeView]
        public IActionResult Privacy()
        {
            return View();
        }
        [ChangeView]
        public IActionResult ActionResult()
        {
            return View("Privacy");
        }
        [ActionResultMix]
        public IActionResult ActionResultMix()
        {
            return View("Privacy");
        }
        [TimeElapsedAsync]
        public string ActionFilter()
        {
            return "Action Filter";
        }
        [ExceptionCatch]
        public string GenerateError()
        {
            throw new NotImplementedException();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
