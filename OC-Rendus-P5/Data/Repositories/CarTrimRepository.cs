using Microsoft.EntityFrameworkCore;
using OC_P5.Data.Repositories.Interfaces;
using OC_P5.Models;

namespace OC_P5.Data.Repositories
{
    public class CarTrimRepository : ICarTrimRepository
    {
        public readonly ApplicationDbContext _context;

        public CarTrimRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CarTrim>> GetAllCarTrimsAsync()
        {
            return await _context.CarTrims.ToListAsync();
        }

        public async Task<CarTrim> GetCarTrimByIdAsync(int CarTrimId)
        {
            return await _context.CarTrims.FirstOrDefaultAsync(c => c.Id == CarTrimId);
        }

        public async Task<CarTrim> GetCarTrimByNameAsync(string trimLabel)
        {
            return await _context.CarTrims.FirstOrDefaultAsync(t => t.TrimLabel == trimLabel);
        }

        public async Task AddCarTrimAsync(CarTrim CarTrim)
        {
            _context.CarTrims.Add(CarTrim);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCarTrimAsync(CarTrim CarTrim)
        {
            _context.CarTrims.Update(CarTrim);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteCarTrimAsync(int CarTrimId)
        {
            CarTrim carTrim = await _context.CarTrims.FindAsync(CarTrimId);
            if (carTrim is not null)
            {
                _context.CarTrims.Remove(carTrim);
                await _context.SaveChangesAsync();
            }
        }
    }
}
