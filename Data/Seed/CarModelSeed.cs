using Microsoft.EntityFrameworkCore;
using OC_P5.Models;

namespace OC_P5.Data.Seed
{
    public class CarModelSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarModel>().HasData(
                new CarModel { Id = 1, Model = "107", CarBrandId = 7},
                new CarModel { Id = 2, Model = "208", CarBrandId = 7},
                new CarModel { Id = 3, Model = "3008", CarBrandId = 7},                
                new CarModel { Id = 4, Model = "A3", CarBrandId = 1},
                new CarModel { Id = 5, Model = "A4", CarBrandId = 1},
                new CarModel { Id = 6, Model = "Q5", CarBrandId = 1},
                new CarModel { Id = 7, Model = "X1", CarBrandId = 2},
                new CarModel { Id = 8, Model = "X3", CarBrandId = 2},
                new CarModel { Id = 9, Model = "M3", CarBrandId = 2},
                new CarModel { Id = 10, Model = "500", CarBrandId = 4},
                new CarModel { Id = 11, Model = "Panda", CarBrandId = 4},
                new CarModel { Id = 12, Model = "Tipo", CarBrandId = 4},
                new CarModel { Id = 13, Model = "Fiesta", CarBrandId = 5},
                new CarModel { Id = 14, Model = "Focus", CarBrandId = 5},
                new CarModel { Id = 15, Model = "Mustang", CarBrandId = 5},
                new CarModel { Id = 16, Model = "A-Class", CarBrandId = 6},
                new CarModel { Id = 17, Model = "C-Class", CarBrandId = 6},
                new CarModel { Id = 18, Model = "E-Class", CarBrandId = 6},
                new CarModel { Id = 19, Model = "Clio", CarBrandId = 8},
                new CarModel { Id = 20, Model = "Captur", CarBrandId = 8},
                new CarModel { Id = 21, Model = "Twingo", CarBrandId = 8},
                new CarModel { Id = 22, Model = "Corolla", CarBrandId = 9},
                new CarModel { Id = 23, Model = "Camry", CarBrandId = 9},
                new CarModel { Id = 24, Model = "RAV4", CarBrandId = 9},
                new CarModel { Id = 25, Model = "Golf", CarBrandId = 10},
                new CarModel { Id = 26, Model = "Passat", CarBrandId = 10},
                new CarModel { Id = 27, Model = "Tiguan", CarBrandId = 10},
                new CarModel { Id = 28, Model = "C3", CarBrandId = 3 },
                new CarModel { Id = 29, Model = "C4", CarBrandId = 3 },
                    new CarModel { Id = 30, Model = "C5", CarBrandId = 3 }
            );
        }
    }
}
