namespace OC_P5.Models
{
    public class YearOfProduction
    {
        public int Id { get; set; }
        public int Year { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
