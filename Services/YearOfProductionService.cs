using OC_P5.Data.Repositories.Interfaces;
using OC_P5.Models;
using OC_P5.Services.Interfaces;

namespace OC_P5.Services
{
    public class YearOfProductionService : IYearOfProductionService
    {
        private readonly IYearOfProductionRepository _yearOfProductionRepository;

        public YearOfProductionService(IYearOfProductionRepository yearOfProductionRepository)
        {
            _yearOfProductionRepository = yearOfProductionRepository;
        }
        public async Task<IEnumerable<YearOfProduction>> GetAllYearsOfProductionAsync()
        {
            return await _yearOfProductionRepository.GetAllYearsAsync();
        }
    }
}
