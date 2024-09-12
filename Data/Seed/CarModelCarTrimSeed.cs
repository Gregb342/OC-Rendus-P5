using Microsoft.EntityFrameworkCore;
using OC_P5.Models;

namespace OC_P5.Data.Seed
{
    public class CarModelCarTrimSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarModelCarTrim>().HasData(
            new CarModelCarTrim { CarModelId = 1, CarTrimId = 1 },
            new CarModelCarTrim { CarModelId = 1, CarTrimId = 2 },
            new CarModelCarTrim { CarModelId = 2, CarTrimId = 1 },
            new CarModelCarTrim { CarModelId = 2, CarTrimId = 3 },
            new CarModelCarTrim { CarModelId = 3, CarTrimId = 2 },
            new CarModelCarTrim { CarModelId = 3, CarTrimId = 4 },
            new CarModelCarTrim { CarModelId = 4, CarTrimId = 3 },
            new CarModelCarTrim { CarModelId = 4, CarTrimId = 5 },
            new CarModelCarTrim { CarModelId = 5, CarTrimId = 4 },
            new CarModelCarTrim { CarModelId = 5, CarTrimId = 1 }
                );
        }
    }
}
