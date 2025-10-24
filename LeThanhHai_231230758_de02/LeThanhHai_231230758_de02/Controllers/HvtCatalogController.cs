using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LeThanhHai_231230758_de02.Data; 
using LeThanhHai_231230758_de02.Models;
using System.Threading.Tasks;
using System.Linq;

namespace LeThanhHai_231230758_de02.Controllers
{
    public class HvtCatalogController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HvtCatalogController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HvtCatalog
        public async Task<IActionResult> Index()
        {
            var list = await _context.HvtCatalog.ToListAsync();
            return View(list);
        }

        // GET: HvtCatalog/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var item = await _context.HvtCatalog.FindAsync(id);
            if (item == null) return NotFound();
            return View(item);
        }

        // GET: Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HvtCatalog hvtCatalog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hvtCatalog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hvtCatalog);
        }

        // GET: Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var item = await _context.HvtCatalog.FindAsync(id);
            if (item == null) return NotFound();
            return View(item);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, HvtCatalog hvtCatalog)
        {
            if (id != hvtCatalog.hvtId) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hvtCatalog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HvtCatalogExists(hvtCatalog.hvtId)) return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(hvtCatalog);
        }

        // GET: Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var item = await _context.HvtCatalog.FindAsync(id);
            if (item == null) return NotFound();
            return View(item);
        }

        // POST: DeleteConfirmed
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.HvtCatalog.FindAsync(id);
            if (item != null)
            {
                _context.HvtCatalog.Remove(item);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
        private bool HvtCatalogExists(int id)
        {
            return _context.HvtCatalog.Any(e => e.hvtId == id);
        }
    }
}
