using Microsoft.AspNetCore.Mvc;
using webproje1.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace webproje1.Controllers
{
    public class EkmekController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EkmekController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ekmek
        public async Task<IActionResult> Index()
        {
            var ekmekler = await _context.Ekmekler.ToListAsync();
            return View(ekmekler);
        }

        // GET: Ekmek/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ekmek = await _context.Ekmekler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ekmek == null)
            {
                return NotFound();
            }

            return View(ekmek);
        }

        // GET: Ekmek/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ekmek/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ad,Aciklama,Fiyat,ResimUrl,Yore,UretimTarihi,StoktaMi")] Ekmek ekmek)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ekmek);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ekmek);
        }

        // GET: Ekmek/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ekmek = await _context.Ekmekler.FindAsync(id);
            if (ekmek == null)
            {
                return NotFound();
            }
            return View(ekmek);
        }

        // POST: Ekmek/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ad,Aciklama,Fiyat,ResimUrl,Yore,UretimTarihi,StoktaMi")] Ekmek ekmek)
        {
            if (id != ekmek.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ekmek);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EkmekExists(ekmek.Id))
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
            return View(ekmek);
        }

        // GET: Ekmek/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ekmek = await _context.Ekmekler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ekmek == null)
            {
                return NotFound();
            }

            return View(ekmek);
        }

        // POST: Ekmek/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ekmek = await _context.Ekmekler.FindAsync(id);
            _context.Ekmekler.Remove(ekmek);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EkmekExists(int id)
        {
            return _context.Ekmekler.Any(e => e.Id == id);
        }
    }
}
