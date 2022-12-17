using Microsoft.AspNetCore.Mvc;
using MyCarStatistics.Models;
using System.Diagnostics;

namespace MyCarStatistics.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
            => _logger = logger;

        [ResponseCache(Duration = 60)]
        public IActionResult Index()
            => View();
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() 
            => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

        [HttpGet]
        [ResponseCache(Duration = 60)]
        public IActionResult AccessDenied()
        {
            _logger.Log(LogLevel.Error, "User {0} try to access forbiden page", User.Identity?.Name);
            return View();
        }

    }
}