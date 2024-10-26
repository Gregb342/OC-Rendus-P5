using OC_P5.Models;
using OC_P5.ViewModels;

namespace OC_P5.Services.Interfaces
{
    public interface ISaleService
    {
        Task<Sale> GetSaleByIdAsync(int id);
        Task<Sale> GetSaleByCarIdAsync(int carId);
        Task AddSaleAsync(Sale sale);
        Task UpdateSaleAsync(int carId, CarViewModel carViewModel);
    }
}
