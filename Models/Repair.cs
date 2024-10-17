using System.ComponentModel.DataAnnotations;

namespace OC_P5.Models
{
    public class Repair
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string Description { get; set; }
        public DateTime RepairDate { get; set; }
        //[Column(TypeName = "decimal(18,2)")]        
        [DataType(DataType.Currency)]
        public decimal RepairCost { get; set; }

        [Required]
        public Car Car { get; set; }
    }
}
