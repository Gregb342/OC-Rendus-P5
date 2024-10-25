namespace OC_P5.Models
{
    public class CarModelCarTrim
    {
        public int CarModelId { get; set; }
        public int CarTrimId { get; set; }

        public virtual CarModel CarModel { get; set; }
        public virtual CarTrim CarTrim { get; set; }
    }
}
