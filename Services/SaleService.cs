using OC_P5.Data.Repositories.Interfaces;
using OC_P5.Models;
using OC_P5.Services.Interfaces;
using OC_P5.ViewModels;

namespace OC_P5.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;

        public SaleService(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task AddSaleAsync(Sale sale)
        {
            await _saleRepository.AddSaleAsync(sale);
        }

        public async Task<Sale> GetSaleByIdAsync(int id)
        {
            return await _saleRepository.GetSaleByIdAsync(id);
        }

        public async Task<Sale> GetSaleByCarIdAsync(int carId)
        {
            return await _saleRepository.GetSaleByCarIdAsync(carId);
        }

        public async Task UpdateSaleAsync(int carId, CarViewModel carViewModel)
        {
            Sale sale = await GetSaleByCarIdAsync(carId);
            if (sale is not null)
            {
                sale.SaleDate = (DateTime)carViewModel.SaleDate;
                sale.SalePrice = (decimal)carViewModel.SalePrice;
            }
            await _saleRepository.UpdateSaleAsync(sale);
        }
    }
}
