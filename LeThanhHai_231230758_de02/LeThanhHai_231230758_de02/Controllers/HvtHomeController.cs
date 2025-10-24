using Microsoft.AspNetCore.Mvc;

namespace LeThanhHai_231230758_de02.Controllers
{
    public class HvtHomeController : Controller
    {
        public IActionResult HvtIndex()
        {
            return View();
        }

        public IActionResult HvtAbout()
        {
            ViewBag.Ten = "Le Thanh Hai";
            ViewBag.MSV = "231230758";
            ViewBag.Lop = "PT12301";
            return View();
        }
    }
}
