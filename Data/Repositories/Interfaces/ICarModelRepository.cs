using OC_P5.Models;

namespace OC_P5.Data.Repositories.Interfaces
{
    public interface ICarModelRepository
    {
        Task<IEnumerable<CarModel>> GetAllCarModelsAsync();
        Task<CarModel> GetCarModelByIdAsync(int carModelId);
        Task<CarModel> GetCarModelByNameAsync(string name);
        Task<IEnumerable<CarModel>> GetCarModelsByBrandIdAsync(int brandId);
        Task AddCarModelAsync(CarModel carModel);
        Task UpdateCarModelAsync(CarModel carModel);
        Task DeleteCarModelAsync(int carModelId);
    }
}
