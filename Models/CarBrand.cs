namespace OC_P5.Models
{
    public class CarBrand
    {
        public int Id { get; set; }
        public string Brand { get; set; }

        public virtual ICollection<CarModel> CarModels { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
}
