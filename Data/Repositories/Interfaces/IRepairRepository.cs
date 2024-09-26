using OC_P5.Models;

namespace OC_P5.Data.Repositories.Interfaces
{
    public interface IRepairRepository
    {
        Task<IEnumerable<Repair>> GetAllRepairsAsync();
        Task<Repair> GetRepairByIdAsync(int repairId);
        Task AddRepairAsync(Repair repair);
        Task UpdateRepairAsync(Repair repair);
        Task DeleteRepairAsync(int repairId);
    }
}
