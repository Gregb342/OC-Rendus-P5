using Humanizer;
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
        private readonly IMediaRepository _mediaRepository;

        public CarService(ICarRepository carRepository, 
                          ICarModelRepository carModelRepository, 
                          ICarBrandRepository carBrandRepository, 
                          IMediaRepository mediaRepository)
        {
            _carRepository = carRepository;
            _carModelRepository = carModelRepository;
            _carBrandRepository = carBrandRepository;
            _mediaRepository = mediaRepository;
        }

        public async Task<IEnumerable<CarViewModel>> GetAllCarsAsync()
        {
            IEnumerable<Car> cars = await _carRepository.GetAllCarsAsync();
            return cars.Select(car => new CarViewModel
            {
                Id = car.Id,
                Label = car.Label,
                VIN = car.VIN,
                Description = car.Description,
                CarBrandId = car.CarBrand.Id,
                CarModelId = car.CarModel.Id,
                CarTrimId = car.CarTrim?.Id,
                YearOfProduction = car.YearOfProduction.Year,
                Status = car.Status
            });
        }

        public async Task<CarViewModel> GetCarByIdAsync(int carId)
        {
            Car car = await _carRepository.GetCarByIdAsync(carId);
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
                Status = car.Status
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
    }
}
