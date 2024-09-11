using Microsoft.EntityFrameworkCore;
using OC_P5.Models;

namespace OC_P5.Data.Seed
{
    public class CarTrimSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarTrim>().HasData(
                new CarTrim { Id = 1, TrimLabel = "Base" },
                new CarTrim { Id = 2, TrimLabel = "Sport" },
                new CarTrim { Id = 3, TrimLabel = "Luxury" },
                new CarTrim { Id = 4, TrimLabel = "Premium" },
                new CarTrim { Id = 5, TrimLabel = "Exclusive" },
                new CarTrim { Id = 6, TrimLabel = "GT" },
                new CarTrim { Id = 7, TrimLabel = "SE" },
                new CarTrim { Id = 8, TrimLabel = "SEL" },
                new CarTrim { Id = 9, TrimLabel = "X-Line" },
                new CarTrim { Id = 10, TrimLabel = "R-Line" },
                new CarTrim { Id = 11, TrimLabel = "Z-Edition" },
                new CarTrim { Id = 12, TrimLabel = "Black Edition" },
                new CarTrim { Id = 13, TrimLabel = "White Edition" },
                new CarTrim { Id = 14, TrimLabel = "S-Line" },
                new CarTrim { Id = 15, TrimLabel = "Avant" },
                new CarTrim { Id = 16, TrimLabel = "Highline" },
                new CarTrim { Id = 17, TrimLabel = "Limited" },
                new CarTrim { Id = 18, TrimLabel = "Ultimate" },
                new CarTrim { Id = 19, TrimLabel = "Sportback" },
                new CarTrim { Id = 20, TrimLabel = "Touring" }
            );
        }
    }
}

