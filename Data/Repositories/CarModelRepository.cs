using Microsoft.EntityFrameworkCore;
using OC_P5.Data.Repositories.Interfaces;
using OC_P5.Models;

namespace OC_P5.Data.Repositories
{
    public class CarModelRepository : ICarModelRepository
    {
        public readonly ApplicationDbContext _context;

        public CarModelRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CarModel>> GetAllCarModelsAsync()
        {
            return await _context.CarModels.ToListAsync();
        }

        public async Task<CarModel> GetCarModelByIdAsync(int carModelId)
        {
            return await _context.CarModels.FirstOrDefaultAsync(c => c.Id == carModelId);
        }

        public async Task<CarModel> GetCarModelByNameAsync(string modelName)
        {
            return await _context.CarModels.FirstOrDefaultAsync(m => m.Model == modelName);
        }

        public async Task<IEnumerable<CarModel>> GetCarModelsByBrandIdAsync(int brandId)
        {
            return await _context.CarModels
                                 .Where(m => m.CarBrandId == brandId)
                                 .ToListAsync();
        }

        public async Task AddCarModelAsync(CarModel carModel)
        {
            _context.CarModels.Add(carModel);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCarModelAsync(CarModel carModel)
        {
            _context.CarModels.Update(carModel);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteCarModelAsync(int carModelId)
        {
            CarModel carModel = await _context.CarModels.FindAsync(carModelId);
            if (carModel is not null)
            {
                _context.CarModels.Remove(carModel);
                await _context.SaveChangesAsync();
            }
        }
    }
}
