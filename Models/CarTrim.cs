namespace OC_P5.Models
{
    public class CarTrim
    {
        public int Id { get; set; }
        public string TrimLabel { get; set; }

        public virtual ICollection<CarCarTrim> CarCarTrims { get; set; }
        public virtual ICollection<Car> Cars { get; set; }


    }
}
