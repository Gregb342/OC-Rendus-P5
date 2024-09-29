namespace OC_P5.Models
{
    public class Car
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

        public virtual YearOfProduction YearOfProduction { get; set; }
        public virtual CarBrand CarBrand { get; set; }
        public virtual CarModel CarModel { get; set; }
        public virtual CarTrim? CarTrim { get; set; }
        public virtual ICollection<CarMedia>? CarMedia { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
        public virtual ICollection<Sale>? Sales { get; set; }
        public virtual ICollection<Repair>? Repairs { get; set; }

    }

    public enum CarStatus
    {
        Purchased = 0,
        Available = 1,        
        Sold = 2   
    }

}
