using IDSps1.Data;
using IDSps1.Models;
using Microsoft.AspNetCore.Mvc;

namespace IDSps1.Controllers
{
    public class NGOController : Controller
    {
       
        private readonly ApplicationDbContext _db;

        public NGOController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Review> objReviews = _db.Reviews;
            return View(objReviews);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Requirements,Link")] Review Reviews)
        {
            if (ModelState.IsValid)
            {
                _db.Add(Reviews);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Reviews);
        }
    }
}
