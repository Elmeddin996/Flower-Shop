using Microsoft.AspNetCore.Mvc;

namespace Flower.UI.Controllers
{
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }

    }
}