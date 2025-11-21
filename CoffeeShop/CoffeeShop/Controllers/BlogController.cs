using Microsoft.AspNetCore.Mvc;
using CoffeeShop.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.Controllers
{
    public class BlogController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BlogController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var pageSize = 6;
            var blogs = _context.Blogs
                .Where(b => b.Status)
                .OrderByDescending(b => b.CreatedAt);

            var totalBlogs = await blogs.CountAsync();
            var totalPages = (int)Math.Ceiling(totalBlogs / (double)pageSize);

            var blogList = await blogs
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.FeaturedBlogs = await _context.Blogs
                .Where(b => b.Featured && b.Status)
                .Take(3)
                .ToListAsync();

            return View(blogList);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var blog = await _context.Blogs
                .FirstOrDefaultAsync(b => b.Id == id && b.Status);

            if (blog == null)
            {
                return NotFound();
            }

            // Related blogs
            var relatedBlogs = await _context.Blogs
                .Where(b => b.Id != id && b.Status)
                .OrderByDescending(b => b.CreatedAt)
                .Take(3)
                .ToListAsync();

            ViewBag.RelatedBlogs = relatedBlogs;
            return View(blog);
        }
    }
}