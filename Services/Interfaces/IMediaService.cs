using OC_P5.Models;

namespace OC_P5.Services.Interfaces
{
    public interface IMediaService
    {
        Task AddMediaToCarAsync(int carId, Media media);
        Task ProcessMediaFilesAsync(int carId, List<IFormFile> mediaFiles);
        Task UpdateMediaFilesAsync(int carId, List<IFormFile> mediaFiles);
    }
}
