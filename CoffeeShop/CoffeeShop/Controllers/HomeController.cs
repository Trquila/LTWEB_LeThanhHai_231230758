using Microsoft.AspNetCore.Mvc;
using CoffeeShop.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var featuredProducts = await _context.Products
                    .Where(p => p.Featured && p.Status)
                    .Include(p => p.Category)
                    .Take(8)
                    .ToListAsync();

                var featuredBlogs = await _context.Blogs
                    .Where(b => b.Featured && b.Status)
                    .Take(3)
                    .ToListAsync();

                ViewBag.FeaturedProducts = featuredProducts;
                ViewBag.FeaturedBlogs = featuredBlogs;
                ViewBag.Categories = await _context.Categories.Where(c => c.Status).ToListAsync();

                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading home page");
                return View("Error");
            }
        }

        public IActionResult About()
        {
            ViewData["Title"] = "Giới thiệu";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public class ErrorViewModel
    {
        public string RequestId { get; set; }
    }
}