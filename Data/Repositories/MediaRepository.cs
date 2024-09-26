using Microsoft.EntityFrameworkCore;
using OC_P5.Data.Repositories.Interfaces;
using OC_P5.Models;

namespace OC_P5.Data.Repositories
{
    public class MediaRepository : IMediaRepository
    {
        private readonly ApplicationDbContext _context;
        public MediaRepository(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<Media>> GetMediaByCarAsync(int carId)
        {
            return await _context.CarMedias
                .Where(cm => cm.CarId == carId)
                .Include(cm => cm.Media)
                .Select(cm => cm.Media)
                .ToListAsync();
        }
    }
}
