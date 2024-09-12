using Microsoft.EntityFrameworkCore;
using OC_P5.Data.Repositories.Interfaces;
using OC_P5.Models;

namespace OC_P5.Data.Repositories
{
    public class CarRepository : ICarRepository
    {
        public readonly ApplicationDbContext _context;

        public CarRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Car>> GetAllCarsAsync()
        {
            return await _context.Cars
                .Include(c => c.CarBrand)
                .Include(c => c.CarModel)
                .Include(c => c.CarTrim)
                .Include(c => c.YearOfProduction)
                .ToListAsync();
        }

        public async Task<Car> GetCarByIdAsync(int carId)
        {
            return await _context.Cars
                .Include(c => c.CarBrand)
                .Include(c => c.CarModel)
                .Include(c => c.CarTrim)
                .Include(c => c.YearOfProduction)
                .FirstOrDefaultAsync(c => c.Id == carId);
        }
        public async Task AddCarAsync(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCarAsync(Car car)
        {
            _context.Cars.Update(car);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteCarAsync(int carId)
        {
            Car car = await _context.Cars.FindAsync(carId);
            if (car is not null)
            {
                _context.Cars.Remove(car);
                await _context.SaveChangesAsync();
            }
        }
    }
}
