using OC_P5.Models;

namespace OC_P5.Data.Repositories.Interfaces
{
    public interface ICarBrandRepository
    {
        Task<IEnumerable<CarBrand>> GetAllCarBrandsAsync();
        Task<CarBrand> GetCarBrandByIdAsync(int carBrandId);
        Task AddCarBrandAsync(CarBrand carBrand);
        Task UpdateCarBrandAsync(CarBrand carBrand);
        Task DeleteCarBrandAsync(int carBrandId);
    }
}
