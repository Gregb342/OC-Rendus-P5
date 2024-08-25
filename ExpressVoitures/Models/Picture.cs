namespace ExpressVoitures.Models
{
    public class Picture
    {
        public int Id { get; set; }
        public string PicturePath { get; set; }
        public int CarID { get; set; }
        public virtual Car Car { get; set; }
    }
}
