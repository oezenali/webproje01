using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using webproje1.Models;

namespace webproje1.Controllers
{
    public class BaharatController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BaharatController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var isAdmin = User.IsInRole("Admin");
            ViewBag.IsAdmin = isAdmin;
            return View(await _context.Baharatlar.ToListAsync());
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baharat = await _context.Baharatlar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (baharat == null)
            {
                return NotFound();
            }

            return View(baharat);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Id,Ad,Aciklama,Fiyat,ResimUrl,Yore,UretimTarihi,StoktaMi")] Baharat baharat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(baharat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(baharat);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baharat = await _context.Baharatlar.FindAsync(id);
            if (baharat == null)
            {
                return NotFound();
            }
            return View(baharat);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ad,Aciklama,Fiyat,ResimUrl,Yore,UretimTarihi,StoktaMi")] Baharat baharat)
        {
            if (id != baharat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(baharat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BaharatExists(baharat.Id))
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
            return View(baharat);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baharat = await _context.Baharatlar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (baharat == null)
            {
                return NotFound();
            }

            return View(baharat);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var baharat = await _context.Baharatlar.FindAsync(id);
            _context.Baharatlar.Remove(baharat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BaharatExists(int id)
        {
            return _context.Baharatlar.Any(e => e.Id == id);
        }
    }
}
