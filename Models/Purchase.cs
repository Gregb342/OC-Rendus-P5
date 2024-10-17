using System.ComponentModel.DataAnnotations;

namespace OC_P5.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public DateTime PurchaseDate { get; set; }
        [DataType(DataType.Currency)]
        public decimal? PurchasePrice { get; set; }


        [Required]
        public Car Car { get; set; }

    }
}
