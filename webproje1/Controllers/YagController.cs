using Microsoft.AspNetCore.Mvc;
using webproje1.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace webproje1.Controllers
{
    public class YagController : Controller
    {
        private readonly ApplicationDbContext _context;

        public YagController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Yag
        public async Task<IActionResult> Index()
        {
            return View(await _context.Yaglar.ToListAsync());
        }

        // GET: Yag/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yag = await _context.Yaglar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (yag == null)
            {
                return NotFound();
            }

            return View(yag);
        }

        // GET: Yag/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Yag/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ad,Aciklama,Fiyat,ResimUrl,Yore,UretimTarihi,StoktaMi")] Yag yag)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yag);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(yag);
        }

        // GET: Yag/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yag = await _context.Yaglar.FindAsync(id);
            if (yag == null)
            {
                return NotFound();
            }
            return View(yag);
        }

        // POST: Yag/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ad,Aciklama,Fiyat,ResimUrl,Yore,UretimTarihi,StoktaMi")] Yag yag)
        {
            if (id != yag.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yag);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YagExists(yag.Id))
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
            return View(yag);
        }

        // GET: Yag/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yag = await _context.Yaglar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (yag == null)
            {
                return NotFound();
            }

            return View(yag);
        }

        // POST: Yag/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var yag = await _context.Yaglar.FindAsync(id);
            _context.Yaglar.Remove(yag);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YagExists(int id)
        {
            return _context.Yaglar.Any(e => e.Id == id);
        }
    }
}
