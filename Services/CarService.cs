using OC_P5.Data.Repositories.Interfaces;
using OC_P5.Models;
using OC_P5.Services.Interfaces;
using OC_P5.ViewModels;

namespace OC_P5.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
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
                CarBrand = car.CarBrand.Brand,
                CarModel = car.CarModel.Model,
                CarTrim = car.CarTrim?.TrimLabel,
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
                CarBrand = car.CarBrand.Brand,
                CarModel = car.CarModel.Model,
                CarTrim = car.CarTrim?.TrimLabel,
                YearOfProduction = car.YearOfProduction.Year,
                Status = car.Status
            };
        }
        public async Task AddCarAsync(CarViewModel carViewModel)
        {
            Car car = new Car
            {
                Label = carViewModel.Label,
                VIN = carViewModel.VIN,
                Description = carViewModel.Description,
                YearOfProductionId = carViewModel.YearOfProductionId,
                CarBrandId = carViewModel.CarBrandId,
                CarModelId = carViewModel.CarModelId,
                CarTrimId = carViewModel.CarTrimId,
                Status = carViewModel.Status
            };
            await _carRepository.AddCarAsync(car);
        }
        public async Task UpdateCarAsync(CarViewModel carViewModel)
        {
            Car car = new Car
            {
                Label = carViewModel.Label,
                VIN = carViewModel.VIN,
                Description = carViewModel.Description,
                YearOfProductionId = carViewModel.YearOfProductionId,
                CarBrandId = carViewModel.CarBrandId,
                CarModelId = carViewModel.CarModelId,
                CarTrimId = carViewModel.CarTrimId,
                Status = carViewModel.Status
            };
            await _carRepository.UpdateCarAsync(car);
        }

        public async Task DeleteCarAsync(int carId)
        {
            await _carRepository.DeleteCarAsync(carId);
        }




    }
}
