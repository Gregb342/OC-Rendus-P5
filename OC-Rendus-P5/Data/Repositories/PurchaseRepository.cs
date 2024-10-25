using Microsoft.EntityFrameworkCore;
using OC_P5.Data.Repositories.Interfaces;
using OC_P5.Models;

namespace OC_P5.Data.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        public readonly ApplicationDbContext _context;

        public PurchaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Purchase>> GetAllPurchasesAsync()
        {
            return await _context.Purchases.ToListAsync();
        }

        public async Task<Purchase> GetPurchaseByIdAsync(int purchaseId)
        {
            return await _context.Purchases.FirstOrDefaultAsync(p => p.Id == purchaseId);
        }
        public async Task<Purchase> GetPurchaseByCarIdAsync(int carId)
        {
            return await _context.Purchases.FirstOrDefaultAsync(p => p.CarId == carId);
        }

        public async Task AddPurchaseAsync(Purchase purchase)
        {
            _context.Purchases.Add(purchase);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePurchaseAsync(Purchase purchase)
        {
            _context.Purchases.Update(purchase);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePurchaseAsync(int purchaseId)
        {
            Purchase purchase = await _context.Purchases.FindAsync(purchaseId);
            if (purchase is not null)
            {
                _context.Purchases.Remove(purchase);
                await _context.SaveChangesAsync();
            }
        }
    }
}
