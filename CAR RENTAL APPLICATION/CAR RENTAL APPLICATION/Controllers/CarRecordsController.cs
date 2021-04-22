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
    public class CarRecordsController : Controller
    {
        private readonly CarsContext _context;

        public CarRecordsController(CarsContext context)
        {
            _context = context;
        }

        // GET: CarRecords
        public async Task<IActionResult> Index()
        {
            var carsContext = _context.CarRecords.Include(c => c.Car).Include(c => c.User);
            return View(await carsContext.ToListAsync());
        }

        // GET: CarRecords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carRecord = await _context.CarRecords
                .Include(c => c.Car)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.CarRecordId == id);
            if (carRecord == null)
            {
                return NotFound();
            }

            return View(carRecord);
        }

        // GET: CarRecords/Create
        public IActionResult Create()
        {
            ViewData["CarId"] = new SelectList(_context.Cars, "CarId", "CarId");
            ViewData["UserId"] = new SelectList(_context.Set<User>(), "UserId", "UserId");
            return View();
        }

        // POST: CarRecords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CarRecordId,UserId,CarId,DateAdded")] CarRecord carRecord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarId"] = new SelectList(_context.Cars, "CarId", "CarId", carRecord.CarId);
            ViewData["UserId"] = new SelectList(_context.Set<User>(), "UserId", "UserId", carRecord.UserId);
            return View(carRecord);
        }

        // GET: CarRecords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carRecord = await _context.CarRecords.FindAsync(id);
            if (carRecord == null)
            {
                return NotFound();
            }
            ViewData["CarId"] = new SelectList(_context.Cars, "CarId", "CarId", carRecord.CarId);
            ViewData["UserId"] = new SelectList(_context.Set<User>(), "UserId", "UserId", carRecord.UserId);
            return View(carRecord);
        }

        // POST: CarRecords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CarRecordId,UserId,CarId,DateAdded")] CarRecord carRecord)
        {
            if (id != carRecord.CarRecordId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarRecordExists(carRecord.CarRecordId))
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
            ViewData["CarId"] = new SelectList(_context.Cars, "CarId", "CarId", carRecord.CarId);
            ViewData["UserId"] = new SelectList(_context.Set<User>(), "UserId", "UserId", carRecord.UserId);
            return View(carRecord);
        }

        // GET: CarRecords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carRecord = await _context.CarRecords
                .Include(c => c.Car)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.CarRecordId == id);
            if (carRecord == null)
            {
                return NotFound();
            }

            return View(carRecord);
        }

        // POST: CarRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carRecord = await _context.CarRecords.FindAsync(id);
            _context.CarRecords.Remove(carRecord);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarRecordExists(int id)
        {
            return _context.CarRecords.Any(e => e.CarRecordId == id);
        }
    }
}
