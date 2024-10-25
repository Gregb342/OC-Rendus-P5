using Microsoft.EntityFrameworkCore;
using OC_P5.Models;

namespace OC_P5.Data.Seed
{
    public class CarMediaSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarMedia>().HasData(
                new CarMedia { CarId = 1, MediaId = 1 },
                new CarMedia { CarId = 2, MediaId = 2 },
                new CarMedia { CarId = 3, MediaId = 3 },
                new CarMedia { CarId = 4, MediaId = 4 },
                new CarMedia { CarId = 5, MediaId = 5 },
                new CarMedia { CarId = 6, MediaId = 6 },
                new CarMedia { CarId = 7, MediaId = 7 },
                new CarMedia { CarId = 8, MediaId = 8 },
                new CarMedia { CarId = 9, MediaId = 9 },
                new CarMedia { CarId = 10, MediaId = 10 }
            );
        }
    }
}
