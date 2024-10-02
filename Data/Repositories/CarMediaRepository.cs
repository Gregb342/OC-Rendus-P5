using Microsoft.EntityFrameworkCore;
using OC_P5.Data.Repositories.Interfaces;
using OC_P5.Models;

namespace OC_P5.Data.Repositories
{
    public class CarMediaRepository : ICarMediaRepository
    {
        private readonly ApplicationDbContext _context;

        public CarMediaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddCarMediaAsync(CarMedia carMedia)
        {
            _context.CarMedias.Add(carMedia);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CarMedia>> GetCarMediasByCarIdAsync(int carId)
        {
            return await _context.CarMedias
                .Where(cm => cm.CarId == carId)
                .Include(cm => cm.Media)
                .ToListAsync();
        }

        public async Task RemoveCarMediaAsync(int carId, int mediaId)
        {
            CarMedia carMedia = await _context.CarMedias
                .FirstOrDefaultAsync(cm => cm.CarId == carId && cm.MediaId == mediaId);

            if (carMedia is not null)
            {
                _context.CarMedias.Remove(carMedia);
                await _context.SaveChangesAsync();
            }
        }
    }

}
