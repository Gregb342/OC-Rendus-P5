namespace ExpressVoitures.ViewModels
{
    public class CarViewModel
    {
        public string CarLabel { get; set; }
        public string VIN { get; set; }
        public bool IsAvailable { get; set; }
        public List<IFormFile> Pictures { get; set; }
    }

}
