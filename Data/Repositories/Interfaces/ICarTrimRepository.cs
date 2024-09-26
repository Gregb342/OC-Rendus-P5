using OC_P5.Models;

namespace OC_P5.Data.Repositories.Interfaces
{
    public interface ICarTrimRepository
    {
        Task<IEnumerable<CarTrim>> GetAllCarTrimsAsync();
        Task<CarTrim> GetCarTrimByIdAsync(int carTrimId);
        Task AddCarTrimAsync(CarTrim carTrim);
        Task UpdateCarTrimAsync(CarTrim carTrim);
        Task DeleteCarTrimAsync(int carTrimId);
    }
}
