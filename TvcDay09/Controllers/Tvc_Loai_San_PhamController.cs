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
    public class Tvc_Loai_San_PhamController : Controller
    {
        private readonly TvcDay09LabCFContext _context;

        public Tvc_Loai_San_PhamController(TvcDay09LabCFContext context)
        {
            _context = context;
        }

        // GET: Tvc_Loai_San_Pham
        public async Task<IActionResult> tvcIndex()
        {
            return View(await _context.tvc_Loai_San_Phams.ToListAsync());
        }

        // GET: Tvc_Loai_San_Pham/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tvc_Loai_San_Pham = await _context.tvc_Loai_San_Phams
                .FirstOrDefaultAsync(m => m.tvcId == id);
            if (tvc_Loai_San_Pham == null)
            {
                return NotFound();
            }

            return View(tvc_Loai_San_Pham);
        }

        // GET: Tvc_Loai_San_Pham/Create
        public IActionResult tvcCreate()
        {
            return View();
        }

        // POST: Tvc_Loai_San_Pham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> tvcCreate([Bind("tvcId,tvcMaLoai,tvcTenLoai,tvcTrangThai")] Tvc_Loai_San_Pham tvc_Loai_San_Pham)
        {
            
                _context.Add(tvc_Loai_San_Pham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(tvcIndex));
            
        }

        // GET: Tvc_Loai_San_Pham/Edit/5
        public async Task<IActionResult> tvcEdit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tvc_Loai_San_Pham = await _context.tvc_Loai_San_Phams.FindAsync(id);
            if (tvc_Loai_San_Pham == null)
            {
                return NotFound();
            }
            return View(tvc_Loai_San_Pham);
        }

        // POST: Tvc_Loai_San_Pham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> tvcEdit(long id, [Bind("tvcId,tvcMaLoai,tvcTenLoai,tvcTrangThai")] Tvc_Loai_San_Pham tvc_Loai_San_Pham)
        {
            if (id != tvc_Loai_San_Pham.tvcId)
            {
                return NotFound();
            }

            
                try
                {
                    _context.Update(tvc_Loai_San_Pham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Tvc_Loai_San_PhamExists(tvc_Loai_San_Pham.tvcId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            
            return View(tvc_Loai_San_Pham);
        }

        // GET: Tvc_Loai_San_Pham/Delete/5
        public async Task<IActionResult> tvcDelete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tvc_Loai_San_Pham = await _context.tvc_Loai_San_Phams
                .FirstOrDefaultAsync(m => m.tvcId == id);
            if (tvc_Loai_San_Pham == null)
            {
                return NotFound();
            }

            return View(tvc_Loai_San_Pham);
        }

        // POST: Tvc_Loai_San_Pham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var tvc_Loai_San_Pham = await _context.tvc_Loai_San_Phams.FindAsync(id);
            if (tvc_Loai_San_Pham != null)
            {
                _context.tvc_Loai_San_Phams.Remove(tvc_Loai_San_Pham);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Tvc_Loai_San_PhamExists(long id)
        {
            return _context.tvc_Loai_San_Phams.Any(e => e.tvcId == id);
        }
    }
}
