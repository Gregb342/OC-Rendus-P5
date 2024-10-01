﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
        private readonly IPurchaseService _purchaseService;
        private readonly IRepairService _repairService;
        private readonly ISaleService _saleService;
        private readonly IMediaService _mediaService;
        private readonly ApplicationDbContext _context;

        public CarsController(ICarService carService, 
                              IPurchaseService purchaseService,
                              IRepairService repairService,
                              ISaleService saleService,
                              IMediaService mediaService,
                              ApplicationDbContext context)
        {
            _context = context;
            _carService = carService;
            _purchaseService = purchaseService;
            _repairService = repairService;
            _saleService = saleService;
            _mediaService = mediaService;
        }

        // GET: Cars
        public async Task<IActionResult> Index()
        {
            IEnumerable<CarViewModel> cars = await _carService.GetAllCarsAsync();

            ViewData["CarBrandColumn"] = "Car Brand";
            ViewData["CarModelColumn"] = "Car Model";
            ViewData["CarTrimColumn"] = "Car Trim";

            foreach (var car in cars)
            {
                ViewData[$"CarBrand_{car.Id}"] = _context.CarBrands.FirstOrDefault(b => b.Id == car.CarBrandId)?.Brand;
                ViewData[$"CarModel_{car.Id}"] = _context.CarModels.FirstOrDefault(m => m.Id == car.CarModelId)?.Model;
                ViewData[$"CarTrim_{car.Id}"] = _context.CarTrims.FirstOrDefault(t => t.Id == car.CarTrimId)?.TrimLabel;

                var media = await _carService.GetCarMediaAsync(car.Id);

                if (media is not null && media.Any())
                {
                    var firstMedia = media.FirstOrDefault();
                    ViewData[$"MediaPath_{car.Id}"] = firstMedia?.Path;
                    ViewData[$"MediaLabel_{car.Id}"] = firstMedia?.Label;
                }
            }
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

            Purchase purchase = await _purchaseService.GetPurchaseByCarIdAsync(car.Id);
            if (purchase != null)
            {
                ViewData["PurchaseDate"] = purchase.PurchaseDate;
                ViewData["PurchasePrice"] = purchase.PurchasePrice;
            }

            Repair repair = await _repairService.GetRepairByCarIdAsync(car.Id);
            if (repair != null)
            {
                ViewData["RepairDate"] = repair.RepairDate;
                ViewData["RepairCost"] = repair.RepairCost;
                ViewData["RepairDescription"] = repair.Description;
            }

            ViewData["CarBrandColumn"] = "Car Brand";
            ViewData["CarModelColumn"] = "Car Model";
            ViewData["CarTrimColumn"] = "Car Trim";

            var carBrand = await _context.CarBrands.FirstOrDefaultAsync(b => b.Id == car.CarBrandId);
            var carModel = await _context.CarModels.FirstOrDefaultAsync(m => m.Id == car.CarModelId);
            var carTrim = await _context.CarTrims.FirstOrDefaultAsync(t => t.Id == car.CarTrimId);

            ViewData["CarBrand"] = carBrand?.Brand;
            ViewData["CarModel"] = carModel?.Model;
            ViewData["CarTrim"] = carTrim?.TrimLabel;

            var media = await _carService.GetCarMediaAsync(car.Id);

            if (media is not null && media.Any())
            {
                var firstMedia = media.FirstOrDefault();
                ViewData["MediaPath"] = firstMedia?.Path;
                ViewData["MediaLabel"] = firstMedia?.Label;
            }

                ViewData["Media"] = media;

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
        public async Task<IActionResult> Create([Bind("Id,Label,VIN,Description,YearOfProductionId,CarBrandId,CarModelId,CarTrimId,Status,PurchaseDate,PurchasePrice,MediaFiles")] CarViewModel carViewModel)
        {
            if (ModelState.IsValid)
            {
                Car car = await _carService.AddCarAsync(carViewModel);

                Purchase purchase = new Purchase
                {
                    CarId = car.Id,
                    PurchaseDate = carViewModel.PurchaseDate ?? DateTime.Now,
                    PurchasePrice = carViewModel.PurchasePrice ?? 0
                };
                await _purchaseService.AddPurchaseAsync(purchase);

                // Traitement des fichiers images
                if (carViewModel.MediaFiles != null && carViewModel.MediaFiles.Count > 0)
                {
                    foreach (var file in carViewModel.MediaFiles)
                    {
                        if (file.Length > 0)
                        {
                            // Sauvegarde du fichier dans le répertoire "wwwroot/medias/pictures"
                            var filePath = Path.Combine("wwwroot/medias/pictures", file.FileName);

                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                await file.CopyToAsync(stream);
                            }

                            // Création d'un objet Media pour l'associer à la voiture
                            Media media = new Media
                            {
                                Path = file.FileName, // Chemin relatif
                                Label = Path.GetFileNameWithoutExtension(file.FileName)
                            };

                            // Ajout à la relation CarMedia
                            await _mediaService.AddMediaToCarAsync(car.Id, media);
                        }
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            // En cas d'erreur dans le formulaire
            bool isModelValid = await _carService.ValidateCarModelWithBrandAsync(carViewModel.CarModelId, carViewModel.CarBrandId);
            if (!isModelValid)
            {
                ModelState.AddModelError("CarModelId", "Le modèle sélectionné n'appartient pas à la marque choisie.");
                return View(carViewModel);
            }

            // Récupération des données pour la liste déroulante en cas de réaffichage de la vue
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
            car.PurchaseDate = (await _purchaseService.GetPurchaseByCarIdAsync(id.Value))?.PurchaseDate;
            car.PurchasePrice = (await _purchaseService.GetPurchaseByCarIdAsync(id.Value))?.PurchasePrice;
            car.RepairDate = (await _repairService.GetRepairByCarIdAsync(id.Value))?.RepairDate;
            car.RepairCost = (await _repairService.GetRepairByCarIdAsync(id.Value))?.RepairCost;
            car.RepairDescription = (await _repairService.GetRepairByCarIdAsync(id.Value))?.Description;
            car.SalePrice = (await _saleService.GetSaleByCarIdAsync(id.Value))?.SalePrice;
            car.SaleDate = (await _saleService.GetSaleByCarIdAsync(id.Value))?.SaleDate;

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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Label,VIN,Description,YearOfProductionId,CarBrandId,CarModelId,CarTrimId,Status,PurchaseDate,PurchasePrice,RepairDescription, RepairDate, RepairCost, SaleDate, SalePrice")] CarViewModel car)
        {
            if (id != car.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _carService.UpdateCarAsync(id, car);
                    await _purchaseService.UpdatePurchaseAsync(id, car);
                    if (car.RepairCost is not null && car.RepairDate is not null)
                    {
                        Repair repair = new Repair
                        {
                            CarId = car.Id,
                            RepairDate = car.RepairDate ?? DateTime.Now,
                            RepairCost = car.RepairCost ?? 0,
                            Description = car.RepairDescription ?? string.Empty
                        };
                        await _repairService.UpdateRepairAsync(id, car);
                        car.Status = CarStatus.Available;
                    }
                    if (car.SalePrice is not null && car.SaleDate is not null)
                    {
                        Sale sale = new Sale
                        {
                            CarId = car.Id,
                            SaleDate = car.SaleDate ?? DateTime.Now,
                            SalePrice = car.SalePrice ?? 0
                        };
                        await _saleService.UpdateSaleAsync(id, car);
                        car.Status = CarStatus.Sold;
                    }
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

            ViewData["CarBrandColumn"] = "Car Brand";
            ViewData["CarModelColumn"] = "Car Model";
            ViewData["CarTrimColumn"] = "Car Trim";

            var carBrand = await _context.CarBrands.FirstOrDefaultAsync(b => b.Id == car.CarBrandId);
            var carModel = await _context.CarModels.FirstOrDefaultAsync(m => m.Id == car.CarModelId);
            var carTrim = await _context.CarTrims.FirstOrDefaultAsync(t => t.Id == car.CarTrimId);

            ViewData["CarBrand"] = carBrand?.Brand;
            ViewData["CarModel"] = carModel?.Model;
            ViewData["CarTrim"] = carTrim?.TrimLabel;

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
