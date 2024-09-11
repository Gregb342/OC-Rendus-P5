using Microsoft.EntityFrameworkCore;
using OC_P5.Models;

namespace OC_P5.Data.Seed
{
    public class CarCarTrimSeed
    {

        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarModelCarTrim>().HasData(
                //new CarModelCarTrim { CarId = 1, CarTrimId = 3 },
                //new CarModelCarTrim { CarId = 2, CarTrimId = 8 },
                //new CarModelCarTrim { CarId = 3, CarTrimId = 12 },
                //new CarModelCarTrim { CarId = 4, CarTrimId = 6 },
                //new CarModelCarTrim { CarId = 5, CarTrimId = 15 },
                //new CarModelCarTrim { CarId = 6, CarTrimId = 20 },
                //new CarModelCarTrim { CarId = 7, CarTrimId = 2 },
                //new CarModelCarTrim { CarId = 8, CarTrimId = 7 },
                //new CarModelCarTrim { CarId = 9, CarTrimId = 19 },
                //new CarModelCarTrim { CarId = 10, CarTrimId = 18 }
            );
        }

    }
}
