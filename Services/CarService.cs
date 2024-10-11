using Humanizer;
using OC_P5.Data.Repositories;
using OC_P5.Data.Repositories.Interfaces;
using OC_P5.Models;
using OC_P5.Services.Interfaces;
using OC_P5.ViewModels;

namespace OC_P5.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly ICarModelRepository _carModelRepository;
        private readonly ICarBrandRepository _carBrandRepository;
        private readonly ICarTrimRepository _carTrimRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly ISaleService _saleService;
        private readonly IPurchaseService _purchaseService;
        private readonly IRepairService _repairService;

        public CarService(ICarRepository carRepository,
                          ICarModelRepository carModelRepository,
                          ICarBrandRepository carBrandRepository,
                          ICarTrimRepository carTrimRepository,
                          IMediaRepository mediaRepository,
                          ISaleService saleService,
                          IPurchaseService purchaseService,
                          IRepairService repairService)
        {
            _carRepository = carRepository;
            _carModelRepository = carModelRepository;
            _carBrandRepository = carBrandRepository;
            _carTrimRepository = carTrimRepository;
            _mediaRepository = mediaRepository;
            _saleService = saleService;
            _purchaseService = purchaseService;
            _repairService = repairService;
        }

        public async Task<IEnumerable<CarViewModel>> GetAllCarsAsync()
        {
            IEnumerable<Car> cars = await _carRepository.GetAllCarsAsync();

            var carViewModels = new List<CarViewModel>();

            foreach (var car in cars)
            {

                var carBrand = await _carBrandRepository.GetCarBrandByIdAsync(car.CarBrandId);
                var carModel = await _carModelRepository.GetCarModelByIdAsync(car.CarModelId);

                CarTrim carTrim = null;
                if (car.CarTrimId.HasValue)
                {
                    carTrim = await _carTrimRepository.GetCarTrimByIdAsync((int)car.CarTrimId);
                }

                var media = await GetCarMediaAsync(car.Id);
                var firstMedia = media?.FirstOrDefault();

                Sale sale = null;
                if (_saleService.GetSaleByCarIdAsync(car.Id).Result != null)
                {
                    sale = await _saleService.GetSaleByCarIdAsync(car.Id);
                }

                var carViewModel = new CarViewModel
                {
                    Id = car.Id,
                    Label = car.Label,
                    VIN = car.VIN,
                    Description = car.Description,
                    CarBrandId = car.CarBrand.Id,
                    CarModelId = car.CarModel.Id,
                    CarTrimId = car.CarTrim?.Id,
                    YearOfProduction = car.YearOfProduction.Year,
                    Status = car.Status,
                    BrandName = carBrand?.Brand ?? "Marque inconnue",
                    ModelName = carModel?.Model ?? "Modele inconnu",
                    TrimName = carTrim?.TrimLabel ?? "Finition inconnue",
                    MediaPath = firstMedia?.Path,
                    MediaLabel = firstMedia?.Label,
                    SaleDate = sale?.SaleDate,
                    SalePrice = sale?.SalePrice
                };

                carViewModels.Add(carViewModel);

            }

            return carViewModels;
        }

        public async Task<CarViewModel> GetCarByIdAsync(int carId)
        {
            Car car = await _carRepository.GetCarByIdAsync(carId);

            var carBrand = await _carBrandRepository.GetCarBrandByIdAsync(car.CarBrandId);
            var carModel = await _carModelRepository.GetCarModelByIdAsync(car.CarModelId);

            CarTrim carTrim = null;
            if (car.CarTrimId.HasValue)
            {
                carTrim = await _carTrimRepository.GetCarTrimByIdAsync((int)car.CarTrimId);
            }

            Sale sale = null;
            if (_saleService.GetSaleByCarIdAsync(car.Id).Result != null)
            {
                sale = await _saleService.GetSaleByCarIdAsync(car.Id);
            }

            Purchase purchase = null;
            if (_purchaseService.GetPurchaseByCarIdAsync(car.Id).Result != null)
            {
                purchase = await _purchaseService.GetPurchaseByCarIdAsync(car.Id);
            }

            Repair repair = null;
            if (_repairService.GetRepairByCarIdAsync(car.Id).Result != null)
            {
                repair = await _repairService.GetRepairByCarIdAsync(car.Id);
            }

            var media = await GetCarMediaAsync(car.Id);
            var firstMedia = media?.FirstOrDefault();

            return new CarViewModel
            {
                Id = car.Id,
                Label = car.Label,
                VIN = car.VIN,
                Description = car.Description,
                CarBrandId = car.CarBrand.Id,
                CarModelId = car.CarModel.Id,
                CarTrimId = car.CarTrim?.Id,
                YearOfProduction = car.YearOfProduction.Year,
                Status = car.Status,
                BrandName = carBrand?.Brand ?? "Marque inconnue",
                ModelName = carModel?.Model ?? "Modele inconnu",
                TrimName = carTrim?.TrimLabel ?? "Finition inconnue",
                MediaPath = firstMedia?.Path,
                MediaLabel = firstMedia?.Label,
                SaleDate = sale?.SaleDate,
                SalePrice = sale?.SalePrice,
                PurchaseDate = purchase.PurchaseDate,
                PurchasePrice = purchase.PurchasePrice,
                RepairDate = repair?.RepairDate,
                RepairCost = repair?.RepairCost,
                RepairDescription = repair?.Description
            };
        }
        public async Task<Car> AddCarAsync(CarViewModel carViewModel)
        {
            CarModel carModel = await _carModelRepository.GetCarModelByIdAsync(carViewModel.CarModelId);
            if (carModel is null || carModel.CarBrandId != carViewModel.CarBrandId)
            {
                throw new Exception("Le modèle sélectionné n'appartient pas à la marque choisie.");
            }

            Car car = new Car
            {
                Label = carViewModel.Label,
                VIN = carViewModel.VIN,
                Description = carViewModel.Description,
                YearOfProductionId = carViewModel.YearOfProductionId,
                CarBrandId = carViewModel.CarBrandId,
                CarModelId = carViewModel.CarModelId,
                CarTrimId = carViewModel.CarTrimId,
                Status = CarStatus.Purchased
            };

            await _carRepository.AddCarAsync(car);
            return car;
        }

        public async Task<IEnumerable<CarModel>> GetCarModelByBrandIdAsync(int brandId)
        {
           return await _carModelRepository.GetCarModelsByBrandIdAsync(brandId);
        }
        public async Task UpdateCarAsync(int carId, CarViewModel carViewModel)
        {
            Car car = await _carRepository.GetCarByIdAsync(carId);
            if (!await (ValidateCarModelWithBrandAsync(carViewModel.CarModelId, carViewModel.CarBrandId)))
            {
                throw new Exception("Le modèle sélectionné n'appartient pas à la marque choisie.");
            }

            car.Label = carViewModel.Label;
            car.VIN = carViewModel.VIN;
            car.Description = carViewModel.Description;
            car.YearOfProductionId = carViewModel.YearOfProductionId;
            car.CarBrandId = carViewModel.CarBrandId;            
            car.CarModelId = carViewModel.CarModelId;
            car.CarTrimId = carViewModel.CarTrimId;
            car.Status = carViewModel.Status;

            await _carRepository.UpdateCarAsync(car);
        }

        public async Task DeleteCarAsync(int carId)
        {
            await _carRepository.DeleteCarAsync(carId);
        }

        public async Task<bool> ValidateCarModelWithBrandAsync(int carModelId, int carBrandId)
        {
            CarModel carModel = await _carModelRepository.GetCarModelByIdAsync(carModelId);
            if (carModel is not null && carModel.CarBrandId == carBrandId) { return true; }
            return false;
        }

        public async Task<IEnumerable<Media>> GetCarMediaAsync(int carId)
        {
            return await _mediaRepository.GetMediaByCarAsync(carId);
        }

        public async Task<bool> CarExistsAsync(int id)
        {
            return await _carRepository.CarExistsAsync(id);
        }


    }
}
