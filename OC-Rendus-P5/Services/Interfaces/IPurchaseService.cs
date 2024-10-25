using OC_P5.Models;
using OC_P5.ViewModels;

namespace OC_P5.Services.Interfaces
{
    public interface IPurchaseService
    {
        Task AddPurchaseAsync(Purchase purchase);
        Task<Purchase> GetPurchaseByCarIdAsync(int carId);

        Task UpdatePurchaseAsync(int carId, CarViewModel carViewModel);

    }
}
