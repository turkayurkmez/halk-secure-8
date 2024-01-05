using DataProtectionOnServer.Models;
using DataProtectionOnServer.Security;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DataProtectionOnServer.Controllers
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
            string value = "Bu cümle acayip gizli";
            DataProtector dataProtector = new DataProtector("info.txt");
            var encryptedLength = dataProtector.EncryptData(value);

            var secretValue = dataProtector.DecryptData(encryptedLength);

            ViewBag.Value = secretValue;

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