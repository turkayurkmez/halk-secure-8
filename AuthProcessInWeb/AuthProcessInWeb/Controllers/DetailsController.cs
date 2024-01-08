using Microsoft.AspNetCore.Mvc;

namespace AuthProcessInWeb.Controllers
{
    public class DetailsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
