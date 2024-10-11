using OC_P5.Models;

namespace OC_P5.Services.Interfaces
{
    public interface IYearOfProductionService
    {
        Task<IEnumerable<YearOfProduction>> GetAllYearsOfProductionAsync();
    }
}
