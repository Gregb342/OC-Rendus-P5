using Microsoft.EntityFrameworkCore;
using OC_P5.Data.Repositories.Interfaces;
using OC_P5.Models;

namespace OC_P5.Data.Repositories
{
    public class CarBrandRepository : ICarBrandRepository
    {
        public readonly ApplicationDbContext _context;

        public CarBrandRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CarBrand>> GetAllCarBrandsAsync()
        {
            return await _context.CarBrands.ToListAsync();
        }

        public async Task<CarBrand> GetCarBrandByIdAsync(int carBrandId)
        {
            return await _context.CarBrands.FirstOrDefaultAsync(c => c.Id == carBrandId);
        }
        public async Task AddCarBrandAsync(CarBrand carBrand)
        {
            _context.CarBrands.Add(carBrand);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateCarBrandAsync(CarBrand carBrand)
        {
            _context.CarBrands.Update(carBrand);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCarBrandAsync(int carBrandId)
        {
            CarBrand carBrand = _context.CarBrands.Find(carBrandId);
            if (carBrand is not null)
            {
                _context.CarBrands.Remove(_context.CarBrands.Find(carBrandId));
                await _context.SaveChangesAsync();
            }
        }
        public async Task<CarBrand> GetCarBrandByNameAsync(string brandName)
        {
            return await _context.CarBrands.FirstOrDefaultAsync(b => b.Brand == brandName);
        }

    }
}
