using Microsoft.AspNetCore.Mvc;

namespace WebPersonal.Backend
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
