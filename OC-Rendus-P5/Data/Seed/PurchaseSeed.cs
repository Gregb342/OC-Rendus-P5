using Microsoft.EntityFrameworkCore;
using OC_P5.Models;

namespace OC_P5.Data.Seed
{
    public class PurchaseSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Purchase>().HasData(
                new Purchase { Id = 1, CarId = 1, PurchaseDate = new DateTime(2023, 1, 15), PurchasePrice = 15000.00M },
                new Purchase { Id = 2, CarId = 2, PurchaseDate = new DateTime(2023, 2, 10), PurchasePrice = 18000.00M },
                new Purchase { Id = 3, CarId = 3, PurchaseDate = new DateTime(2023, 3, 5), PurchasePrice = 20000.00M },
                new Purchase { Id = 4, CarId = 4, PurchaseDate = new DateTime(2023, 4, 1), PurchasePrice = 17000.00M },
                new Purchase { Id = 5, CarId = 5, PurchaseDate = new DateTime(2023, 5, 15), PurchasePrice = 16000.00M },
                new Purchase { Id = 6, CarId = 6, PurchaseDate = new DateTime(2023, 6, 25), PurchasePrice = 19000.00M },
                new Purchase { Id = 7, CarId = 7, PurchaseDate = new DateTime(2023, 7, 18), PurchasePrice = 22000.00M },
                new Purchase { Id = 8, CarId = 8, PurchaseDate = new DateTime(2023, 8, 9), PurchasePrice = 21000.00M },
                new Purchase { Id = 9, CarId = 9, PurchaseDate = new DateTime(2023, 9, 12), PurchasePrice = 23000.00M },
                new Purchase { Id = 10, CarId = 10, PurchaseDate = new DateTime(2023, 10, 1), PurchasePrice = 25000.00M }
            );
        }
    }
}
