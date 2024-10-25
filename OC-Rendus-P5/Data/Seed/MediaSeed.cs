using Microsoft.EntityFrameworkCore;
using OC_P5.Models;

namespace OC_P5.Data.Seed
{
    public class MediaSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Media>().HasData(
                new Media { Id = 1, Label = "Car 1 Image", Path = "/medias/pictures/Car (1).jpg", TypeOfMediaId = 1 },
                new Media { Id = 2, Label = "Car 2 Image", Path = "/medias/pictures/Car (2).jpg", TypeOfMediaId = 1 },
                new Media { Id = 3, Label = "Car 3 Image", Path = "/medias/pictures/Car (3).jpg", TypeOfMediaId = 1 },
                new Media { Id = 4, Label = "Car 4 Image", Path = "/medias/pictures/Car (4).jpg", TypeOfMediaId = 1 },
                new Media { Id = 5, Label = "Car 5 Image", Path = "/medias/pictures/Car (5).jpg", TypeOfMediaId = 1 },
                new Media { Id = 6, Label = "Car 6 Image", Path = "/medias/pictures/Car (6).jpg", TypeOfMediaId = 1 },
                new Media { Id = 7, Label = "Car 7 Image", Path = "/medias/pictures/Car (7).jpg", TypeOfMediaId = 1 },
                new Media { Id = 8, Label = "Car 8 Image", Path = "/medias/pictures/Car (8).jpg", TypeOfMediaId = 1 },
                new Media { Id = 9, Label = "Car 9 Image", Path = "/medias/pictures/Car (9).jpg", TypeOfMediaId = 1 },
                new Media { Id = 10, Label = "Car 10 Image", Path = "/medias/pictures/Car (10).jpg", TypeOfMediaId = 1 }
            );
        }
    }
}
