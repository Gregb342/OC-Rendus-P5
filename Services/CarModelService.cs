
using OC_P5.Data.Repositories.Interfaces;
using OC_P5.Models;
using OC_P5.Services.Interfaces;

namespace OC_P5.Services
{
    public class CarModelService : ICarModelService
    {
        private readonly ICarModelRepository _carModelRepository;
        private readonly ICarBrandService _carBrandService;

        public CarModelService(ICarModelRepository carModelRepository, ICarBrandService carBrandService)
        {
            _carModelRepository = carModelRepository;
            _carBrandService = carBrandService;
        }

        public async Task<IEnumerable<CarModel>> GetAllCarModelsAsync()
        {
            return await _carModelRepository.GetAllCarModelsAsync();
        }

        public async Task<CarModel> GetCarModelByIdAsync(int modelId)
        {
            return await _carModelRepository.GetCarModelByIdAsync(modelId);
        }
        public async Task<CarModel> AddNewModelAsync(string modelName, int brandId)
        {
            CarBrand existingBrand = await _carBrandService.GetCarBrandByIdAsync(brandId);
            if (existingBrand == null)
            {
                throw new InvalidOperationException("La marque spécifiée est introuvable.");
            }

            CarModel existingModel = await _carModelRepository.GetCarModelByNameAsync(modelName);
            if (existingModel != null)
            {
                throw new InvalidOperationException("Ce modèle existe déjà.");
            }

            CarModel newModel = new CarModel
            {
                Model = modelName,
                CarBrandId = brandId,
                CarBrand = existingBrand
            };

            await _carModelRepository.AddCarModelAsync(newModel);

            return newModel;
        }
    }
}
