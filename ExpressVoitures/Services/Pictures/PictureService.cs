using ExpressVoitures.Interfaces.Pictures;

namespace ExpressVoitures.Services.Pictures
{
    public class PictureService : IPictures
    {
        private readonly string _imageDirectory;

        public PictureService(IWebHostEnvironment env)
        {
            _imageDirectory = Path.Combine(env.WebRootPath, "uploads");
        }

        public async Task<string> UploadImageAsync(IFormFile image)
        {
            if (image == null || image.Length == 0)
            {
                throw new ArgumentException("Fichier image invalide");
            }

            string fileName = Path.GetFileName(image.FileName);
            string filePath = Path.Combine(_imageDirectory, fileName);

            using(var stream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }

            return fileName;
        }

        public void DeleteImage(string imagePath)
        {
            string fullPath = Path.Combine(_imageDirectory, imagePath);
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
        }
    }
}
