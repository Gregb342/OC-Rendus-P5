using OC_P5.Models;

namespace OC_P5.Services.Interfaces
{
    public interface ICarBrandService
    {
        Task<IEnumerable<CarBrand>> GetAllCarBrandsAsync();
        Task<CarBrand> GetCarBrandByIdAsync(int brandId);
        Task<CarBrand> AddNewBrandAsync(string brandName);
    }
}
