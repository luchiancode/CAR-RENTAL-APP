using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CAR_RENTAL_APPLICATION.Models;

namespace CAR_RENTAL_APPLICATION.Controllers
{
    public class newslettersController : Controller
    {
        private readonly CarsContext _context;

        public newslettersController(CarsContext context)
        {
            _context = context;
        }

        // GET: newsletters
        public async Task<IActionResult> Index()
        {
            return View(await _context.newsletterlogs.ToListAsync());
        }

        // GET: newsletters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsletter = await _context.newsletterlogs
                .FirstOrDefaultAsync(m => m.newsletterId == id);
            if (newsletter == null)
            {
                return NotFound();
            }

            return View(newsletter);
        }

        // GET: newsletters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: newsletters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("newsletterId,title")] newsletter newsletter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newsletter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(newsletter);
        }

        // GET: newsletters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsletter = await _context.newsletterlogs.FindAsync(id);
            if (newsletter == null)
            {
                return NotFound();
            }
            return View(newsletter);
        }

        // POST: newsletters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("newsletterId,title")] newsletter newsletter)
        {
            if (id != newsletter.newsletterId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(newsletter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!newsletterExists(newsletter.newsletterId))
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
            return View(newsletter);
        }

        // GET: newsletters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsletter = await _context.newsletterlogs
                .FirstOrDefaultAsync(m => m.newsletterId == id);
            if (newsletter == null)
            {
                return NotFound();
            }

            return View(newsletter);
        }

        // POST: newsletters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var newsletter = await _context.newsletterlogs.FindAsync(id);
            _context.newsletterlogs.Remove(newsletter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool newsletterExists(int id)
        {
            return _context.newsletterlogs.Any(e => e.newsletterId == id);
        }
    }
}
