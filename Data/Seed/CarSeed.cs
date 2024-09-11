using Microsoft.EntityFrameworkCore;
using OC_P5.Models;

namespace OC_P5.Data.Seed
{
    public class CarSeed
    {

        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasData(
                new Car { Id = 1, Label = "Car 1", VIN = "1HGCM82633A123456", Description = "Car description 1", YearOfProductionId = 1, Status = CarStatus.Available },
                new Car { Id = 2, Label = "Car 2", VIN = "1HGCM82633A654321", Description = "Car description 2", YearOfProductionId = 2, Status = CarStatus.Purchased },
                new Car { Id = 3, Label = "Car 3", VIN = "1HGCM82633A789456", Description = "Car description 3", YearOfProductionId = 3, Status = CarStatus.InRepair },
                new Car { Id = 4, Label = "Car 4", VIN = "1HGCM82633A987654", Description = "Car description 4", YearOfProductionId = 4, Status = CarStatus.Available },
                new Car { Id = 5, Label = "Car 5", VIN = "1HGCM82633A456789", Description = "Car description 5", YearOfProductionId = 5, Status = CarStatus.Sold },
                new Car { Id = 6, Label = "Car 6", VIN = "1HGCM82633A321654", Description = "Car description 6", YearOfProductionId = 6, Status = CarStatus.InRepair },
                new Car { Id = 7, Label = "Car 7", VIN = "1HGCM82633A159753", Description = "Car description 7", YearOfProductionId = 7, Status = CarStatus.Available },
                new Car { Id = 8, Label = "Car 8", VIN = "1HGCM82633A357951", Description = "Car description 8", YearOfProductionId = 8, Status = CarStatus.Sold },
                new Car { Id = 9, Label = "Car 9", VIN = "1HGCM82633A753159", Description = "Car description 9", YearOfProductionId = 9, Status = CarStatus.Purchased },
                new Car { Id = 10, Label = "Car 10", VIN = "1HGCM82633A852963", Description = "Car description 10", YearOfProductionId = 10, Status = CarStatus.InRepair }
            );
        }

    }
}
