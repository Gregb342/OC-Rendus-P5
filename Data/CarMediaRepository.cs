using OC_P5.Data.Repositories.Interfaces;
using OC_P5.Models;

namespace OC_P5.Data
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
    }

}
