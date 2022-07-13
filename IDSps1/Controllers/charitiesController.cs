using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IDSps1.Data;
using IDSps1.Models;
using Microsoft.AspNetCore.Authorization;

namespace IDSps1.Controllers
{
    public class charitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public charitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: charities
        public async Task<IActionResult> Index()
        {
              return _context.Charity != null ? 
                          View(await _context.Charity.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.charity'  is null.");
        }

        // GET: charity/ShowSearchForm
        public async Task<IActionResult> ShowSearchForm()
        {
            return View();        
        }

        // POST: charity/ShowSearchResults
        public async Task<IActionResult> ShowSearchResults(String SearchPhrase)
        {
            return View("Index", await _context.Charity.Where( j => j.NGO.Contains(SearchPhrase)).ToListAsync());
        }

        // GET: charities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Charity == null)
            {
                return NotFound();
            }

            var charity = await _context.Charity
                .FirstOrDefaultAsync(m => m.Id == id);
            if (charity == null)
            {
                return NotFound();
            }

            return View(charity);
        }

        // GET: charities/Create
        
        public IActionResult Create()
        {
            return View();
        }

        // POST: charities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NGO,Requirements")] Charity charity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(charity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(charity);
        }

        // GET: charities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Charity == null)
            {
                return NotFound();
            }

            var charity = await _context.Charity.FindAsync(id);
            if (charity == null)
            {
                return NotFound();
            }
            return View(charity);
        }

        // POST: charities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NGO,Requirements")] Charity charity)
        {
            if (id != charity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(charity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!charityExists(charity.Id))
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
            return View(charity);
        }

       

        // GET: charities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Charity == null)
            {
                return NotFound();
            }

            var charity = await _context.Charity
                .FirstOrDefaultAsync(m => m.Id == id);
            if (charity == null)
            {
                return NotFound();
            }

            return View(charity);
        }

        // POST: charities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Charity == null)
            {
                return Problem("Entity set 'ApplicationDbContext.charity'  is null.");
            }
            var charity = await _context.Charity.FindAsync(id);
            if (charity != null)
            {
                _context.Charity.Remove(charity);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool charityExists(int id)
        {
          return (_context.Charity?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
