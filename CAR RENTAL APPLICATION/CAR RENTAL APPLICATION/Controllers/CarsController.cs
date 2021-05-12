using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CAR_RENTAL_APPLICATION.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using CAR_RENTAL_APPLICATION.Repositories;
using CAR_RENTAL_APPLICATION.ViewModels;

namespace CAR_RENTAL_APPLICATION.Controllers
{
    public class CarsController : Controller
    {
        private readonly CarsContext _context;
        private readonly IHostingEnvironment hostingEnvironment;

        public CarsController(CarsContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            this.hostingEnvironment = hostingEnvironment;
        }

        // GET: Cars
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cars.ToListAsync());
        }

        // GET: Cars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .FirstOrDefaultAsync(m => m.CarId == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: Cars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CarsCreateViewModel car)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (car.CarImage != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath + "/images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + car.CarImage.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    car.CarImage.CopyTo(new FileStream(filePath, FileMode.Create));
                  //  string folder = "cars/images";
                  //  folder +=  Guid.NewGuid().ToString() + "_" + car.CarImage.FileName ;
                  //  string serverFolder = Path.Combine(_webHostEnviroment.WebRootPath, folder);

                    //await  car.CarImage.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                }
                Car newCar = new Car
                {
                    Brand = car.Brand,
                    Colour = car.Colour,
                    Capacity = car.Capacity,
                    NumberOfDoors = car.Capacity,
                    FabricationYear = car.FabricationYear,
                    CarImagePath = uniqueFileName

                };
                _context.Add(newCar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CarId,Brand,Colour,Capacity,NumberOfDoors,FabricationYear")] Car car)
        {
            if (id != car.CarId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(car);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.CarId))
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
            return View(car);
        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .FirstOrDefaultAsync(m => m.CarId == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(int id)
        {
            return _context.Cars.Any(e => e.CarId == id);
        }
    }
}
