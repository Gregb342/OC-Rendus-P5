using Microsoft.EntityFrameworkCore;
using OC_P5.Models;

namespace OC_P5.Data.Seed
{
    public class CarSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasData(
                new Car { Id = 1, Label = "Car 1", VIN = "1HGCM82633A123456", Description = "Car description 1", YearOfProductionId = 1, CarBrandId = 1, CarModelId = 1, CarTrimId = null, Status = CarStatus.Available },
                new Car { Id = 2, Label = "Car 2", VIN = "1HGCM82633A654321", Description = "Car description 2", YearOfProductionId = 2, CarBrandId = 2, CarModelId = 2, CarTrimId = 1, Status = CarStatus.Purchased },
                new Car { Id = 3, Label = "Car 3", VIN = "1HGCM82633A789456", Description = "Car description 3", YearOfProductionId = 3, CarBrandId = 3, CarModelId = 3, CarTrimId = 2, Status = CarStatus.Purchased },
                new Car { Id = 4, Label = "Car 4", VIN = "1HGCM82633A987654", Description = "Car description 4", YearOfProductionId = 4, CarBrandId = 4, CarModelId = 4, CarTrimId = 3, Status = CarStatus.Available },
                new Car { Id = 5, Label = "Car 5", VIN = "1HGCM82633A456789", Description = "Car description 5", YearOfProductionId = 5, CarBrandId = 5, CarModelId = 5, CarTrimId = 4, Status = CarStatus.Sold },
                new Car { Id = 6, Label = "Car 6", VIN = "1HGCM82633A321654", Description = "Car description 6", YearOfProductionId = 6, CarBrandId = 6, CarModelId = 6, CarTrimId = 5, Status = CarStatus.Available },
                new Car { Id = 7, Label = "Car 7", VIN = "1HGCM82633A159753", Description = "Car description 7", YearOfProductionId = 7, CarBrandId = 7, CarModelId = 7, CarTrimId = 6, Status = CarStatus.Available },
                new Car { Id = 8, Label = "Car 8", VIN = "1HGCM82633A357951", Description = "Car description 8", YearOfProductionId = 8, CarBrandId = 8, CarModelId = 8, CarTrimId = 7, Status = CarStatus.Sold },
                new Car { Id = 9, Label = "Car 9", VIN = "1HGCM82633A753159", Description = "Car description 9", YearOfProductionId = 9, CarBrandId = 9, CarModelId = 9, CarTrimId = 8, Status = CarStatus.Purchased },
                new Car { Id = 10, Label = "Car 10", VIN = "1HGCM82633A852963", Description = "Car description 10", YearOfProductionId = 10, CarBrandId = 10, CarModelId = 10, CarTrimId = 9, Status = CarStatus.Available }
            );
        }
    }   
}
