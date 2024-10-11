using OC_P5.Data.Repositories;
using OC_P5.Data.Repositories.Interfaces;
using OC_P5.Models;
using OC_P5.Services.Interfaces;

namespace OC_P5.Services
{
    public class CarModelService : ICarModelService
    {
        private readonly ICarModelRepository _carModelRepository;

        public CarModelService(ICarModelRepository carModelRepository)
        {
            _carModelRepository = carModelRepository;
        }

        public async Task<IEnumerable<CarModel>> GetAllCarModelsAsync()
        {
            return await _carModelRepository.GetAllCarModelsAsync();
        }

        public async Task<CarModel> GetCarModelByIdAsync(int modelId)
        {
            return await _carModelRepository.GetCarModelByIdAsync(modelId);
        }
        public async Task<CarModel> AddNewModelAsync(string modelName)
        {
            CarModel existingModel = await _carModelRepository.GetCarModelByNameAsync(modelName);
            if (existingModel != null)
            {
                throw new InvalidOperationException("Ce modèle existe déjà.");
            }

            CarModel newModel = new CarModel { Model = modelName };
            await _carModelRepository.AddCarModelAsync(newModel);

            return newModel;
        }
    }
}
