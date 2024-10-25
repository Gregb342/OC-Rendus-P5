using OC_P5.Models;
using OC_P5.ViewModels;

namespace OC_P5.Services.Interfaces
{
    public interface IRepairService
    {
        Task AddRepairAsync(Repair repair);
        Task<Repair> GetRepairByCarIdAsync(int carId);
        Task UpdateRepairAsync(int carId, CarViewModel carViewModel);
    }
}
