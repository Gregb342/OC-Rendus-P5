using OC_P5.Data.Repositories.Interfaces;
using OC_P5.Models;
using OC_P5.Services.Interfaces;
using OC_P5.ViewModels;

namespace OC_P5.Services
{
    public class RepairService : IRepairService
    {
        private readonly IRepairRepository _repairRepository;
        public RepairService(IRepairRepository repairRepository)
        {
            _repairRepository = repairRepository;
        }
        public async Task<Repair> GetRepairByCarIdAsync(int carId)
        {
            return await _repairRepository.GetRepairByCarIdAsync(carId);
        }

        public async Task AddRepairAsync(Repair repair)
        {
            await _repairRepository.AddRepairAsync(repair);
        }

        public async Task UpdateRepairAsync(int carId, CarViewModel carViewModel)
        {
            var repair = await GetRepairByCarIdAsync(carId);
            if (repair is not null)
            {
                repair.Description = carViewModel.RepairDescription;
                repair.RepairDate = (DateTime)carViewModel.RepairDate;
                repair.RepairCost = (decimal)carViewModel.RepairCost;
            }
            await _repairRepository.UpdateRepairAsync(repair);
        }
    }
}
