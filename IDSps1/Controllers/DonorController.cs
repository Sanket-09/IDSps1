using IDSps1.Data;
using IDSps1.Models;
using Microsoft.AspNetCore.Mvc;

namespace IDSps1.Controllers
{
    public class DonorController : Controller
    {
        private readonly ApplicationDbContext _database;

        public DonorController(ApplicationDbContext db)
        {
            _database = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Charity> objcharity = _database.Charity;
            return View(objcharity);
        }

        public IActionResult Payment()
        {
            return View();
        }
    }
}
