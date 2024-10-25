using Microsoft.EntityFrameworkCore;
using OC_P5.Models;

namespace OC_P5.Data.Seed
{
    public class CarBrandSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarBrand>().HasData(
                new CarBrand { Id = 1, Brand = "Audi" },
                new CarBrand { Id = 2, Brand = "BMW" },
                new CarBrand { Id = 3, Brand = "Citroën" },
                new CarBrand { Id = 4, Brand = "Fiat" },
                new CarBrand { Id = 5, Brand = "Ford" },
                new CarBrand { Id = 6, Brand = "Mercedes" },
                new CarBrand { Id = 7, Brand = "Peugeot" },
                new CarBrand { Id = 8, Brand = "Renault" },
                new CarBrand { Id = 9, Brand = "Toyota" },
                new CarBrand { Id = 10, Brand = "Volkswagen" }
            );
        }
    }
}
