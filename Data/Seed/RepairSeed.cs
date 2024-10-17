using Microsoft.EntityFrameworkCore;
using OC_P5.Models;

namespace OC_P5.Data.Seed
{
    public class RepairSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Repair>().HasData(
                new Repair { Id = 1, CarId = 1, RepairDate = new DateTime(2023, 3, 10), RepairCost = 500.00M, Description = "Repair description 1" },
                new Repair { Id = 2, CarId = 3, RepairDate = new DateTime(2023, 4, 5), RepairCost = 700.00M, Description = "Repair description 2" },
                new Repair { Id = 3, CarId = 4, RepairDate = new DateTime(2023, 5, 20), RepairCost = 600.00M, Description = "Repair description 3" },
                new Repair { Id = 4, CarId = 5, RepairDate = new DateTime(2023, 6, 30), RepairCost = 800.00M, Description = "Repair description 4" },
                new Repair { Id = 5, CarId = 6, RepairDate = new DateTime(2023, 7, 25), RepairCost = 900.00M, Description = "Repair description 5" },
                new Repair { Id = 6, CarId = 7, RepairDate = new DateTime(2023, 8, 15), RepairCost = 1000.00M, Description = "Repair description 6" },
                new Repair { Id = 7, CarId = 8, RepairDate = new DateTime(2023, 9, 5), RepairCost = 1100.00M, Description = "Repair description 7" },
                new Repair { Id = 8, CarId = 10, RepairDate = new DateTime(2023, 10, 10), RepairCost = 1200.00M, Description = "Repair description 8" }
                );
        }
    }
}
