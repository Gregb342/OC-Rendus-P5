using OC_P5.Models;

namespace OC_P5.ViewModels
{
    public class CarViewModel
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public string VIN { get; set; }
        public string Description { get; set; }
        public int YearOfProductionId { get; set; }
        public int CarBrandId { get; set; }
        public int CarModelId { get; set; }
        public int? CarTrimId { get; set; }
        public CarStatus Status { get; set; }

        public int YearOfProduction { get; set; }
        public string CarBrand { get; set; }
        public string CarModel { get; set; }
        public string? CarTrim { get; set; }
    }
}
