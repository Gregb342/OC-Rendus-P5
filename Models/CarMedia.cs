namespace OC_P5.Models
{
    public class CarMedia
    {
        public int CarId { get; set; } 
        public int MediaId { get; set; }

        public virtual Car Car { get; set; }
        public virtual Media Media { get; set; }
    }
}
