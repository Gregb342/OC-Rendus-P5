using Microsoft.EntityFrameworkCore;

namespace OC_P5.Models
{
    public class SaleSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sale>().HasData(

                new Sale { Id = 1, CarId = 5, SaleDate = new DateTime(2023, 1, 15), SalePrice = 20000.00M },
                new Sale { Id = 2, CarId = 8, SaleDate = new DateTime(2023, 2, 10), SalePrice = 23000.00M }
            );
        }
    }
}
