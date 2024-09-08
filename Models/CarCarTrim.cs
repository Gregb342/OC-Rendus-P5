namespace OC_P5.Models
{
    public class CarCarTrim
    {
        public int CarId { get; set; }
        public int CarTrimId { get; set; }

        public virtual Car Car { get; set; }
        public virtual CarTrim CarTrim { get; set; }
    }
}
