namespace OC_P5.Models
{
    public class CarModel
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int CarBrandId { get; set; }

        public virtual CarBrand CarBrand { get; set; }
        public virtual ICollection<CarTrim> CarTrims { get; set; }
    }
}
