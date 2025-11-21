using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Về chúng tôi";
            return View();
        }
    }
}