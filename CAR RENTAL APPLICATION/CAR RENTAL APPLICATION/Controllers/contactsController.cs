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
    public class contactsController : Controller
    {
        private readonly CarsContext _context;

        public contactsController(CarsContext context)
        {
            _context = context;
        }

        // GET: contacts
        public async Task<IActionResult> Index()
        {
            var carsContext = _context.contactlogs.Include(c => c.mailingList);
            return View(await carsContext.ToListAsync());
        }

        // GET: contacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.contactlogs
                .Include(c => c.mailingList)
                .FirstOrDefaultAsync(m => m.contactId == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // GET: contacts/Create
        public IActionResult Create()
        {
            ViewData["mailingListId"] = new SelectList(_context.mailingListlogs, "mailingListId", "mailingListId");
            return View();
        }

        // POST: contacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("contactId,email,text,mailingListId")] contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["mailingListId"] = new SelectList(_context.mailingListlogs, "mailingListId", "mailingListId", contact.mailingListId);
            return View(contact);
        }

        // GET: contacts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.contactlogs.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            ViewData["mailingListId"] = new SelectList(_context.mailingListlogs, "mailingListId", "mailingListId", contact.mailingListId);
            return View(contact);
        }

        // POST: contacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("contactId,email,text,mailingListId")] contact contact)
        {
            if (id != contact.contactId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!contactExists(contact.contactId))
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
            ViewData["mailingListId"] = new SelectList(_context.mailingListlogs, "mailingListId", "mailingListId", contact.mailingListId);
            return View(contact);
        }

        // GET: contacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.contactlogs
                .Include(c => c.mailingList)
                .FirstOrDefaultAsync(m => m.contactId == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // POST: contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contact = await _context.contactlogs.FindAsync(id);
            _context.contactlogs.Remove(contact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool contactExists(int id)
        {
            return _context.contactlogs.Any(e => e.contactId == id);
        }
    }
}
