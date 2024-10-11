using Microsoft.EntityFrameworkCore;
using OC_P5.Data.Repositories.Interfaces;
using OC_P5.Models;

namespace OC_P5.Data.Repositories
{
    public class YearOfProductionRepository : IYearOfProductionRepository
    {
        private readonly ApplicationDbContext _context;

        public YearOfProductionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<YearOfProduction>> GetAllYearsAsync()
        {
            return await _context.YearOfProductions.ToListAsync();
        }
    }
}
