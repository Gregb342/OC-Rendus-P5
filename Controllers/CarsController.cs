using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OC_P5.Data;
using OC_P5.Models;
using OC_P5.Services;
using OC_P5.Services.Interfaces;
using OC_P5.ViewModels;

namespace OC_P5.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarService _carService;
        private readonly ApplicationDbContext _context;

        public CarsController(ICarService carService,ApplicationDbContext context)
        {
            _carService = carService;
            _context = context;
        }

        // GET: Cars
        public async Task<IActionResult> Index()
        {
            IEnumerable<CarViewModel> cars = await _carService.GetAllCarsAsync();
            return View(cars);
        }

        // GET: Cars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            CarViewModel car = await _carService.GetCarByIdAsync(id.Value);
            if (car is null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: Cars/Create
        public IActionResult Create()
        {
            ViewData["CarBrandId"] = new SelectList(_context.CarBrands, "Id", "Brand");
            ViewData["CarModelId"] = new SelectList(_context.CarModels, "Id", "Model");
            ViewData["CarTrimId"] = new SelectList(_context.CarTrims, "Id", "TrimLabel");
            ViewData["YearOfProductionId"] = new SelectList(_context.YearOfProductions, "Id", "Year");
            return View();
        }

        // POST: Cars/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Label,VIN,Description,YearOfProductionId,CarBrandId,CarModelId,CarTrimId,Status")] CarViewModel carViewModel)
        {
            if (ModelState.IsValid)
            {
                await _carService.AddCarAsync(carViewModel);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarBrandId"] = new SelectList(_context.CarBrands, "Id", "Brand", carViewModel.CarBrandId);
            ViewData["CarModelId"] = new SelectList(_context.CarModels, "Id", "Model", carViewModel.CarModelId);
            ViewData["CarTrimId"] = new SelectList(_context.CarTrims, "Id", "TrimLabel", carViewModel.CarTrimId);
            ViewData["YearOfProductionId"] = new SelectList(_context.YearOfProductions, "Id", "Year", carViewModel.YearOfProductionId);
            return View(carViewModel);
        }

        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            CarViewModel car = await _carService.GetCarByIdAsync(id.Value);
            if (car is null)
            {
                return NotFound();
            }
            ViewData["CarBrandId"] = new SelectList(_context.CarBrands, "Id", "Brand", car.CarBrandId);
            ViewData["CarModelId"] = new SelectList(_context.CarModels, "Id", "Model", car.CarModelId);
            ViewData["CarTrimId"] = new SelectList(_context.CarTrims, "Id", "TrimLabel", car.CarTrimId);
            ViewData["YearOfProductionId"] = new SelectList(_context.YearOfProductions, "Id", "Year", car.YearOfProductionId);
            return View(car);
        }

        // POST: Cars/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Label,VIN,Description,YearOfProductionId,CarBrandId,CarModelId,CarTrimId,Status")] CarViewModel car)
        {
            if (id != car.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _carService.UpdateCarAsync(car);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.Id))
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
            ViewData["CarBrandId"] = new SelectList(_context.CarBrands, "Id", "Brand", car.CarBrandId);
            ViewData["CarModelId"] = new SelectList(_context.CarModels, "Id", "Model", car.CarModelId);
            ViewData["CarTrimId"] = new SelectList(_context.CarTrims, "Id", "TrimLabel", car.CarTrimId);
            ViewData["YearOfProductionId"] = new SelectList(_context.YearOfProductions, "Id", "Year", car.YearOfProductionId);
            return View(car);
        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            CarViewModel car = await _carService.GetCarByIdAsync(id.Value);
            if (car is null)
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
            await _carService.DeleteCarAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(int id)
        {
          return (_context.Cars?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
