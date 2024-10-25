using OC_P5.Models;

namespace OC_P5.Services.Interfaces
{
    public interface ICarTrimService
    {
        Task<IEnumerable<CarTrim>> GetAllCarTrimsAsync();
        Task<CarTrim> GetCarTrimByIdAsync(int trimId);
        Task<CarTrim> AddNewCarTrimAsync(string trimName);
    }
}
