using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OC_P5.Models;
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
        private readonly ICarTrimService _carTrimService;
        private readonly ICarModelService _carModelService;
        private readonly ICarBrandService _carBrandService;
        private readonly IYearOfProductionService _yearOfProductionService;
        private readonly ILogger<CarsController> _logger;

        public CarsController(ICarService carService,
                              IPurchaseService purchaseService,
                              IRepairService repairService,
                              ISaleService saleService,
                              IMediaService mediaService,
                              ICarTrimService carTrimService,
                              ICarModelService carModelService,
                              ICarBrandService carBrandService,
                              IYearOfProductionService yearOfProductionService,
                              ILogger<CarsController> logger)
        {
            _carService = carService;
            _purchaseService = purchaseService;
            _repairService = repairService;
            _saleService = saleService;
            _mediaService = mediaService;
            _carTrimService = carTrimService;
            _carModelService = carModelService;
            _carBrandService = carBrandService;
            _yearOfProductionService = yearOfProductionService;
            _logger = logger;
        }

        // GET: Cars
        public async Task<IActionResult> Index()
        {
            var cars = await _carService.GetAllCarsAsync();
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

            var media = await _carService.GetCarMediaAsync(car.Id);
            if (media is not null && media.Any())
            {
                var firstMedia = media.FirstOrDefault();
                car.MediaPath = firstMedia?.Path;
                car.MediaLabel = firstMedia?.Label;
            }

            return View(car);
        }

        // GET: Cars/Create
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            CarViewModel viewModel = new CarViewModel();

            viewModel = await PopulateViewModelSelectListsAsync(viewModel);

            return View(viewModel);
        }

        // POST: Cars/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Label,VIN,Description,YearOfProductionId,CarBrandId,CarModelId,CarTrimId,Status,PurchaseDate,PurchasePrice,MediaFiles")] CarViewModel carViewModel)
        {
            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    _logger.LogError("Erreurs dans CREATE/POST : " + error.ErrorMessage);
                }
                return View(carViewModel);
            }

            bool isModelValid = await _carService.ValidateCarModelWithBrandAsync(carViewModel.CarModelId, carViewModel.CarBrandId);
            if (!isModelValid)
            {
                ModelState.AddModelError("CarModelId", "Le modèle sélectionné n'appartient pas à la marque choisie.");
                return View(carViewModel);
            }

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

                if (carViewModel.MediaFiles != null && carViewModel.MediaFiles.Count > 0)
                {
                    try
                    {
                        await _mediaService.ProcessMediaFilesAsync(car.Id, carViewModel.MediaFiles);
                        return View("CreateConfirmation");
                    }
                    catch (InvalidOperationException ex)
                    {
                        ModelState.AddModelError("MediaFiles", ex.Message);
                        return View(carViewModel);
                    }
                }
                return View("CreateConfirmation");
            }

            carViewModel = await PopulateViewModelSelectListsAsync(carViewModel);

            return View(carViewModel);
        }

        // GET: Cars/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            CarViewModel car = await _carService.GetCarByIdAsync(id.Value);
            var media = await _carService.GetCarMediaAsync(car.Id);
            if (media is not null && media.Any())
            {
                var firstMedia = media.FirstOrDefault();
                car.MediaPath = firstMedia?.Path;
                car.MediaLabel = firstMedia?.Label;
            }
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

            car = await PopulateViewModelSelectListsAsync(car);
            return View(car);
        }

        // POST: Cars/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Label,VIN,Description,YearOfProductionId,CarBrandId,CarModelId,CarTrimId,Status,PurchaseDate,PurchasePrice,RepairDescription, RepairDate, RepairCost, SaleDate, SalePrice, MediaFiles")] CarViewModel car)
        {
            if (id != car.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    _logger.LogError("Erreurs dans EDIT/POST : " + error.ErrorMessage);
                }
                return View(car);
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
                    try
                    {
                        if (car.MediaFiles != null && car.MediaFiles.Count > 0)
                        {
                            await _mediaService.UpdateMediaFilesAsync(car.Id, car.MediaFiles);
                        }
                    }
                    catch (InvalidOperationException ex)
                    {
                        ModelState.AddModelError("MediaFiles", ex.Message);
                        return View(car);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _carService.CarExistsAsync(car.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return View("EditConfirmation", car);
            }

            car = await PopulateViewModelSelectListsAsync(car);

            return View(car);
        }

        // GET: Cars/Delete/5
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var car = await _carService.GetCarByIdAsync(id);
            await _carService.DeleteCarAsync(id);
            return View("DeleteConfirmation", car);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<JsonResult> GetCarModelsByBrand(int brandId)
        {
            var carModels = await _carService.GetCarModelByBrandIdAsync(brandId);
            var result = carModels.Select(car => new { car.Id, car.Model }).ToList();
            return Json(result);
        }

        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> AddBrand(string brandName)
        {
            if (string.IsNullOrEmpty(brandName))
            {
                return Json(new { success = false });
            }

            try
            {
                var newBrand = await _carBrandService.AddNewBrandAsync(brandName);
                return Json(new { success = true, brand = new { Id = newBrand.Id, Brand = newBrand.Brand } });
            }
            catch (InvalidOperationException ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> AddModel(string modelName, int brandId)
        {
            if (string.IsNullOrEmpty(modelName) || brandId <= 0)
            {
                return Json(new { success = false });
            }

            try
            {
                var newModel = await _carModelService.AddNewModelAsync(modelName, brandId);
                return Json(new { success = true, model = new { Id = newModel.Id, Model = newModel.Model, BrandId = newModel.CarBrandId } });
            }
            catch (InvalidOperationException ex)
            {
                return Json(new { sucess = false, message = ex.Message });
            }
        }

        private async Task<CarViewModel> PopulateViewModelSelectListsAsync(CarViewModel viewModel = null)
        {
            viewModel ??= new CarViewModel();

            viewModel.CarBrands = new SelectList(await _carBrandService.GetAllCarBrandsAsync(), "Id", "Brand", viewModel.CarBrandId);
            viewModel.CarModels = new SelectList(await _carModelService.GetAllCarModelsAsync(), "Id", "Model", viewModel.CarModelId);
            viewModel.CarTrims = new SelectList(await _carTrimService.GetAllCarTrimsAsync(), "Id", "TrimLabel", viewModel.CarTrimId);
            viewModel.YearsOfProduction = new SelectList(await _yearOfProductionService.GetAllYearsOfProductionAsync(), "Id", "Year", viewModel.YearOfProductionId);

            return viewModel;
        }

    }
}
