using OC_P5.Data.Repositories.Interfaces;
using OC_P5.Models;
using OC_P5.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

public class MediaService : IMediaService
{
    private readonly IMediaRepository _mediaRepository;
    private readonly ICarMediaRepository _carMediaRepository;

    public MediaService(IMediaRepository mediaRepository, ICarMediaRepository carMediaRepository)
    {
        _mediaRepository = mediaRepository;
        _carMediaRepository = carMediaRepository;
    }

    public async Task AddMediaToCarAsync(int carId, Media media)
    {
        await _mediaRepository.AddMediaAsync(media);

        CarMedia carMedia = new CarMedia
        {
            CarId = carId,
            MediaId = media.Id
        };

        await _carMediaRepository.AddCarMediaAsync(carMedia);
    }

    public async Task ProcessMediaFilesAsync(int carId, List<IFormFile> mediaFiles)
    {
        foreach (IFormFile file in mediaFiles)
        {
            if (file.ContentType != "image/jpeg" && file.ContentType != "image/png")
            {
                throw new InvalidOperationException("Les fichiers doivent être de type image (jpeg ou png).");
            }

            if (file.Length > 0)
            {
                string filePath = Path.Combine("wwwroot/medias/pictures", file.FileName);

                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                Media media = new Media
                {
                    Path = "/medias/pictures/" + file.FileName,
                    Label = Path.GetFileNameWithoutExtension(file.FileName),
                    TypeOfMediaId = 1 // Supposant qu'il s'agit d'une image
                };

                await AddMediaToCarAsync(carId, media);
            }
        }
    }

    public async Task UpdateMediaFilesAsync(int carId, List<IFormFile> mediaFiles)
    {       
       var existingMedias = await _carMediaRepository.GetCarMediasByCarIdAsync(carId);
        foreach (var carMedia in existingMedias)
        {
            await _carMediaRepository.RemoveCarMediaAsync(carMedia.CarId, carMedia.MediaId);
            await _mediaRepository.RemoveMediaAsync(carMedia.MediaId);            
        }

        if (mediaFiles != null && mediaFiles.Count > 0)
        {
            await ProcessMediaFilesAsync(carId, mediaFiles);
        }
    }
}
