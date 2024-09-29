using OC_P5.Data.Repositories.Interfaces;
using OC_P5.Models;
using OC_P5.Services.Interfaces;
using OC_P5.ViewModels;

namespace OC_P5.Services
{    
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository _purchaseRepository;

        public PurchaseService(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }

        public async Task<Purchase> GetPurchaseByCarIdAsync(int carId)
        {
            return await _purchaseRepository.GetPurchaseByCarIdAsync(carId);
        }

        public async Task AddPurchaseAsync(Purchase purchase)
        {
            await _purchaseRepository.AddPurchaseAsync(purchase);
        }

        public async Task UpdatePurchaseAsync(int carId, CarViewModel carViewModel)
        {
            Purchase purchase = await GetPurchaseByCarIdAsync(carId);
            if (purchase is not null)
            {
                purchase.PurchaseDate = (DateTime)carViewModel.PurchaseDate;
                purchase.PurchasePrice = (decimal)carViewModel.PurchasePrice;
            }
            await _purchaseRepository.UpdatePurchaseAsync(purchase);
        }
    }
}
