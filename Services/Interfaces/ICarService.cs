using OC_P5.Models;
using OC_P5.ViewModels;

namespace OC_P5.Services.Interfaces
{
    public interface ICarService
    {
        Task<IEnumerable<CarViewModel>> GetAllCarsAsync();
        Task<CarViewModel> GetCarByIdAsync(int carId);
        Task AddCarAsync(CarViewModel carViewModel);
        Task UpdateCarAsync(int carid, CarViewModel carViewModel);
        Task DeleteCarAsync(int carId);
        Task<bool> ValidateCarModelWithBrandAsync(int carModelId, int carBrandId);
        Task<IEnumerable<Media>> GetCarMediaAsync(int carId);
    }
}
