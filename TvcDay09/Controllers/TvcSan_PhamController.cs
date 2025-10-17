using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TvcDay09.Models;

namespace TvcDay09.Controllers
{
    public class TvcSan_PhamController : Controller
    {
        private readonly TvcDay09LabCFContext _context;

        public TvcSan_PhamController(TvcDay09LabCFContext context)
        {
            _context = context;
        }

        // GET: TvcSan_Pham
        public async Task<IActionResult> Index()
        {
            return View(await _context.TvcSan_Phams.ToListAsync());
        }

        // GET: TvcSan_Pham/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tvcSan_Pham = await _context.TvcSan_Phams
                .FirstOrDefaultAsync(m => m.tvcID == id);
            if (tvcSan_Pham == null)
            {
                return NotFound();
            }

            return View(tvcSan_Pham);
        }

        // GET: TvcSan_Pham/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TvcSan_Pham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("tvcID,tvcMaSanPham,tvcTenSanPham,tvcHinhAnh,tvcSoLuong,tvcDonGia,tvcLoaiSanPhamID")] TvcSan_Pham tvcSan_Pham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tvcSan_Pham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tvcSan_Pham);
        }

        // GET: TvcSan_Pham/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tvcSan_Pham = await _context.TvcSan_Phams.FindAsync(id);
            if (tvcSan_Pham == null)
            {
                return NotFound();
            }
            return View(tvcSan_Pham);
        }

        // POST: TvcSan_Pham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("tvcID,tvcMaSanPham,tvcTenSanPham,tvcHinhAnh,tvcSoLuong,tvcDonGia,tvcLoaiSanPhamID")] TvcSan_Pham tvcSan_Pham)
        {
            if (id != tvcSan_Pham.tvcID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tvcSan_Pham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TvcSan_PhamExists(tvcSan_Pham.tvcID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tvcSan_Pham);
        }

        // GET: TvcSan_Pham/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tvcSan_Pham = await _context.TvcSan_Phams
                .FirstOrDefaultAsync(m => m.tvcID == id);
            if (tvcSan_Pham == null)
            {
                return NotFound();
            }

            return View(tvcSan_Pham);
        }

        // POST: TvcSan_Pham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var tvcSan_Pham = await _context.TvcSan_Phams.FindAsync(id);
            if (tvcSan_Pham != null)
            {
                _context.TvcSan_Phams.Remove(tvcSan_Pham);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TvcSan_PhamExists(long id)
        {
            return _context.TvcSan_Phams.Any(e => e.tvcID == id);
        }
    }
}
