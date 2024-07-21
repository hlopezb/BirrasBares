using Microsoft.AspNetCore.Mvc;

namespace BirrasBares.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}