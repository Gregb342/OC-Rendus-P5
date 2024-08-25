namespace ExpressVoitures.Models
{
    public class Car
    {
        public Car()
        {
            this.Pictures = new List<Picture>();
        }
        public int Id { get; set; }
        public string? CarLabel { get; set; }
        public string? VIN { get; set; }
        public bool IsAvailable { get; set; }
        public virtual List<Picture> Pictures { get; set; }

        // TODO : rajouter les FK vers YearsOfProduction, CarTrim


    }
}
