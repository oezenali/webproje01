using Microsoft.AspNetCore.Mvc;
using webproje1.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace webproje1.Controllers
{
    public class RecelController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RecelController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Recel
        public async Task<IActionResult> Index()
        {
            var receller = await _context.Receller.ToListAsync();
            return View(receller);
        }

        // GET: Recel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recel = await _context.Receller
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recel == null)
            {
                return NotFound();
            }

            return View(recel);
        }

        // GET: Recel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Recel/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ad,Aciklama,Fiyat,ResimUrl,Yore,UretimTarihi,StoktaMi")] Recel recel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recel);
        }

        // GET: Recel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recel = await _context.Receller.FindAsync(id);
            if (recel == null)
            {
                return NotFound();
            }
            return View(recel);
        }

        // POST: Recel/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ad,Aciklama,Fiyat,ResimUrl,Yore,UretimTarihi,StoktaMi")] Recel recel)
        {
            if (id != recel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecelExists(recel.Id))
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
            return View(recel);
        }

        // GET: Recel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recel = await _context.Receller
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recel == null)
            {
                return NotFound();
            }

            return View(recel);
        }

        // POST: Recel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recel = await _context.Receller.FindAsync(id);
            _context.Receller.Remove(recel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecelExists(int id)
        {
            return _context.Receller.Any(e => e.Id == id);
        }
    }
}
