namespace ExpressVoitures.Interfaces.Pictures
{
    public interface IPictures
    {
        Task<string> UploadImageAsync(IFormFile image);
        void DeleteImage(string imagePath);
    }
}
