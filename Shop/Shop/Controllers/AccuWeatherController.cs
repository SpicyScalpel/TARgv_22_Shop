using Microsoft.AspNetCore.Mvc;

namespace Shop.Controllers
{
    public class AccuWeatherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
