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
    public class mailingListsController : Controller
    {
        private readonly CarsContext _context;

        public mailingListsController(CarsContext context)
        {
            _context = context;
        }

        // GET: mailingLists
        public async Task<IActionResult> Index()
        {
            var carsContext = _context.mailingListlogs.Include(m => m.newsletter);
            return View(await carsContext.ToListAsync());
        }

        // GET: mailingLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mailingList = await _context.mailingListlogs
                .Include(m => m.newsletter)
                .FirstOrDefaultAsync(m => m.mailingListId == id);
            if (mailingList == null)
            {
                return NotFound();
            }

            return View(mailingList);
        }

        // GET: mailingLists/Create
        public IActionResult Create()
        {
            ViewData["newsletterId"] = new SelectList(_context.newsletterlogs, "newsletterId", "newsletterId");
            return View();
        }

        // POST: mailingLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("mailingListId,email,name,address,address2,city,state,zip,policy,newsletterId")] mailingList mailingList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mailingList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["newsletterId"] = new SelectList(_context.newsletterlogs, "newsletterId", "newsletterId", mailingList.newsletterId);
            return View(mailingList);
        }

        // GET: mailingLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mailingList = await _context.mailingListlogs.FindAsync(id);
            if (mailingList == null)
            {
                return NotFound();
            }
            ViewData["newsletterId"] = new SelectList(_context.newsletterlogs, "newsletterId", "newsletterId", mailingList.newsletterId);
            return View(mailingList);
        }

        // POST: mailingLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("mailingListId,email,name,address,address2,city,state,zip,policy,newsletterId")] mailingList mailingList)
        {
            if (id != mailingList.mailingListId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mailingList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!mailingListExists(mailingList.mailingListId))
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
            ViewData["newsletterId"] = new SelectList(_context.newsletterlogs, "newsletterId", "newsletterId", mailingList.newsletterId);
            return View(mailingList);
        }

        // GET: mailingLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mailingList = await _context.mailingListlogs
                .Include(m => m.newsletter)
                .FirstOrDefaultAsync(m => m.mailingListId == id);
            if (mailingList == null)
            {
                return NotFound();
            }

            return View(mailingList);
        }

        // POST: mailingLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mailingList = await _context.mailingListlogs.FindAsync(id);
            _context.mailingListlogs.Remove(mailingList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool mailingListExists(int id)
        {
            return _context.mailingListlogs.Any(e => e.mailingListId == id);
        }
    }
}
