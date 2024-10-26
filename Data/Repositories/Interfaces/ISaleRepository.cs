using OC_P5.Models;

namespace OC_P5.Data.Repositories.Interfaces
{
    public interface ISaleRepository
    {
        Task<IEnumerable<Sale>> GetAllSalesAsync();
        Task<Sale> GetSaleByIdAsync(int saleId);
        Task<Sale> GetSaleByCarIdAsync(int carId);
        Task AddSaleAsync(Sale sale);
        Task UpdateSaleAsync(Sale sale);
        Task DeleteSaleAsync(int saleId);
    }
}
