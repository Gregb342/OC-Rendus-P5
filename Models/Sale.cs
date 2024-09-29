using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OC_P5.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public DateTime SaleDate { get; set; }        
        public decimal SalePrice { get; set; }

        [Required]
        public Car Car { get; set; }
    }
}
