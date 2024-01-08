using Microsoft.AspNetCore.Mvc;

namespace AuthProcessInWeb.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Login(string? gidilecekSayfa)
        {
            return View();
        }
    }
}
