using OC_P5.Data.Repositories.Interfaces;
using OC_P5.Models;
using OC_P5.Services.Interfaces;

namespace OC_P5.Services
{
    public class CarBrandService : ICarBrandService
    {
        private readonly ICarBrandRepository _carBrandRepository;

        public CarBrandService(ICarBrandRepository carBrandRepository)
        {
            _carBrandRepository = carBrandRepository;
        }

        public async Task<IEnumerable<CarBrand>> GetAllCarBrandsAsync()
        {
            return await _carBrandRepository.GetAllCarBrandsAsync();
        }

        public async Task<CarBrand> GetCarBrandByIdAsync(int brandId)
        {
            return await _carBrandRepository.GetCarBrandByIdAsync(brandId);
        }

        public async Task<CarBrand> AddNewBrandAsync(string brandName)
        {
            CarBrand existingBrand = await _carBrandRepository.GetCarBrandByNameAsync(brandName);
            if (existingBrand != null)
            {
                throw new InvalidOperationException("Cette marque existe déjà.");
            }

            CarBrand newBrand = new CarBrand { Brand = brandName };
            await _carBrandRepository.AddCarBrandAsync(newBrand);

            return newBrand;
        }

    }
}
