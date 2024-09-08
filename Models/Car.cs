namespace OC_P5.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public string VIN { get; set; }
        public string Description { get; set; }
        public int YearOfProductionId { get; set; }
        public int CarTrimId { get; set; }


        public bool IsAvailable { get; set; } 
        public virtual ICollection<CarCarTrim> CarCarTrim { get; set; }
        public virtual ICollection<CarMedia> CarMedia { get; set; }
        public virtual YearOfProduction YearOfProduction { get; set; }

    }

}
