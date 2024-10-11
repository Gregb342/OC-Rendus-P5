using OC_P5.Models;

namespace OC_P5.Data.Repositories.Interfaces
{
    public interface IYearOfProductionRepository
    {
        Task<IEnumerable<YearOfProduction>> GetAllYearsAsync();
    }
}
