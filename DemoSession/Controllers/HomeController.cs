using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DemoSession.Models;
using Microsoft.AspNetCore.Http;
using DemoSession.Infrastructure;

namespace DemoSession.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISessionManager _sessionManager;

        public HomeController(ILogger<HomeController> logger, ISessionManager sessionManager)
        {
            _logger = logger;
            _sessionManager = sessionManager;
        }

        public IActionResult Index()
        {
            _sessionManager.Test = "Hello";
            _sessionManager.AddToPanier("Pomme");
            return View();
        }

        public IActionResult Panier()
        {
            return View(_sessionManager.Panier);
        }

        public IActionResult Privacy()
        {
            ViewBag.Test = _sessionManager.Test;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
