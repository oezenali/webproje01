using Microsoft.AspNetCore.Mvc;
using webproje1.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace webproje1.Controllers
{
    public class BaharatController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BaharatController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Baharat
        public async Task<IActionResult> Index()
        {
            var baharatlar = await _context.Baharatlar.ToListAsync();
            return View(baharatlar);
        }

        // GET: Baharat/Details/5
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

        // GET: Baharat/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Baharat/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        // GET: Baharat/Edit/5
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

        // POST: Baharat/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        // GET: Baharat/Delete/5
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

        // POST: Baharat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
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
