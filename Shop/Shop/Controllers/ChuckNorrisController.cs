using Microsoft.AspNetCore.Mvc;
using Shop.Core.Dto.ChuckNorrisDtos;
using Shop.Core.ServiceInterface;
using Shop.Models.ChuckNorrises;

namespace Shop.Controllers
{
    public class ChuckNorrisController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
