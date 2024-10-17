using Microsoft.EntityFrameworkCore;
using OC_P5.Data.Repositories.Interfaces;
using OC_P5.Models;

namespace OC_P5.Data.Repositories
{
    public class RepairRepository : IRepairRepository
    {
        public readonly ApplicationDbContext _context;

        public RepairRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Repair>> GetAllRepairsAsync()
        {
            return await _context.Repairs.ToListAsync();
        }

        public async Task<Repair> GetRepairByIdAsync(int RepairId)
        {
            return await _context.Repairs.FirstOrDefaultAsync(p => p.Id == RepairId);
        }

        public async Task<Repair> GetRepairByCarIdAsync(int carId)
        {
            return await _context.Repairs.FirstOrDefaultAsync(p => p.CarId == carId);
        }

        public async Task AddRepairAsync(Repair Repair)
        {
            _context.Repairs.Add(Repair);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRepairAsync(Repair Repair)
        {
            _context.Repairs.Update(Repair);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRepairAsync(int RepairId)
        {
            Repair repair = await _context.Repairs.FindAsync(RepairId);
            if (repair is not null)
            {
                _context.Repairs.Remove(repair);
                await _context.SaveChangesAsync();
            }
        }
    }
}
