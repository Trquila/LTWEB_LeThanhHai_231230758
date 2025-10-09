using Microsoft.AspNetCore.Mvc;
using WebLab3.Models;

namespace WebLab3.Controllers
{
    public class BookController : Controller
    {
        // Hiển thị danh sách sách
        public IActionResult Index()
        {
            Book bookModel = new Book();
            var books = bookModel.GetBookList();
            ViewBag.authors = bookModel.Authors;
            ViewBag.genres = bookModel.Genres;
            return View(books);
        }

        // Partial View load bằng Ajax
        public PartialViewResult PopularBook()
        {
            Book bookModel = new Book();
            var books = bookModel.GetBookList();
            return PartialView("_PopularBook", books);
        }

        // GET: Edit
        public IActionResult Edit(int id)
        {
            Book bookModel = new Book();
            var book = bookModel.GetBookById(id);
            ViewBag.authors = bookModel.Authors;
            ViewBag.genres = bookModel.Genres;
            return View(book);
        }

        // GET: Create (hiển thị form thêm mới)
        public IActionResult Create()
        {
            Book bookModel = new Book();
            ViewBag.authors = bookModel.Authors;
            ViewBag.genres = bookModel.Genres;
            return View(new Book());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book model)
        {
            if (ModelState.IsValid)
            {
                // TODO: thêm sách vào DB (demo hiện chưa có DB)
                return RedirectToAction("Index");
            }
            Book bookModel = new Book();
            ViewBag.authors = bookModel.Authors;
            ViewBag.genres = bookModel.Genres;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Book model)
        {
            if (ModelState.IsValid)
            {
                // TODO: cập nhật DB
                return RedirectToAction("Index");
            }
            Book bookModel = new Book();
            ViewBag.authors = bookModel.Authors;
            ViewBag.genres = bookModel.Genres;
            return View(model);
        }
    }
}
