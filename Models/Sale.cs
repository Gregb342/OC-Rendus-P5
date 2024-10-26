using System.ComponentModel.DataAnnotations;

namespace OC_P5.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public DateTime SaleDate { get; set; }
        //[Column(TypeName = "decimal(18,2)")]        
        [DataType(DataType.Currency)]
        public decimal SalePrice { get; set; }

        [Required]
        public Car Car { get; set; }
    }
}
