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
        
    }
}
