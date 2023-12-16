using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webproje1.Models;

namespace webproje1.Controllers
{
    public class FeedbackController : Controller
    {

        private readonly ApplicationDbContext _context;
        public FeedbackController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: FeedbackController
        public ActionResult Index()
        {
            return View();
        }

        // GET: FeedbackController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FeedbackController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FeedbackController/Create
        // Kullanıcıdan gelen feedback bilgisini alıp veritabanına kaydetmek için bir POST eylemi
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Message")] Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                _context.Add(feedback);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(feedback);
        }

        
        // GET: FeedbackController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FeedbackController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FeedbackController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FeedbackController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
