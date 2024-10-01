using OC_P5.Data.Repositories.Interfaces;
using OC_P5.Models;
using OC_P5.Services.Interfaces;
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
}
