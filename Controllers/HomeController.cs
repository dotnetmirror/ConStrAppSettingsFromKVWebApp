using ConStrAppSettingsFromKVWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ConStrAppSettingsFromKVWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            // This securely pulls the value straight from the Key Vault provider
            string? connectionString = _configuration.GetConnectionString("DefaultConnection");
            // You can then pass this connection string to your view using ViewBag or a ViewModel
            ViewBag.MyConnectionString = connectionString;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
