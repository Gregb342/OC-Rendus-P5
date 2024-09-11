using Microsoft.EntityFrameworkCore;
using OC_P5.Models;

namespace OC_P5.Data.Seed
{
    public class TypeOfMediaSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TypeOfMedia>().HasData(
                new TypeOfMedia { Id = 1, Type = "Image" },
                new TypeOfMedia { Id = 2, Type = "PDF" },
                new TypeOfMedia { Id = 3, Type = "Doc" }
            );
        }
    }
}
