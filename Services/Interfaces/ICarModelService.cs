using OC_P5.Models;

namespace OC_P5.Services.Interfaces
{
    public interface ICarModelService
    {
        Task<IEnumerable<CarModel>> GetAllCarModelsAsync();
        Task<CarModel> GetCarModelByIdAsync(int modelId);
        Task<CarModel> AddNewModelAsync(string modelName);
    }
}
