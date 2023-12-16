using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using webproje1.Models;

namespace webproje1.Controllers
{
    public class YelekController : Controller
    {
        private readonly ApplicationDbContext _context;

        public YelekController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Yelek
        public async Task<IActionResult> Index()
        {
            var isAdmin = User.IsInRole("Admin");
            ViewBag.IsAdmin = isAdmin;
            return View(await _context.Yelekler.ToListAsync());
        }

        // GET: Yelek/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yelek = await _context.Yelekler.FirstOrDefaultAsync(m => m.Id == id);
            if (yelek == null)
            {
                return NotFound();
            }

            return View(yelek);
        }

        // GET: Yelek/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Yelek/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Id,Ad,Aciklama,Fiyat,ResimUrl,Yore,UretimTarihi,StoktaMi")] Yelek yelek)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yelek);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(yelek);
        }

        // GET: Yelek/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yelek = await _context.Yelekler.FindAsync(id);
            if (yelek == null)
            {
                return NotFound();
            }
            return View(yelek);
        }

        // POST: Yelek/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ad,Aciklama,Fiyat,ResimUrl,Yore,UretimTarihi,StoktaMi")] Yelek yelek)
        {
            if (id != yelek.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yelek);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YelekExists(yelek.Id))
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
            return View(yelek);
        }

        // GET: Yelek/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yelek = await _context.Yelekler.FirstOrDefaultAsync(m => m.Id == id);
            if (yelek == null)
            {
                return NotFound();
            }

            return View(yelek);
        }

        // POST: Yelek/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var yelek = await _context.Yelekler.FindAsync(id);
            _context.Yelekler.Remove(yelek);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YelekExists(int id)
        {
            return _context.Yelekler.Any(e => e.Id == id);
        }
    }
}
