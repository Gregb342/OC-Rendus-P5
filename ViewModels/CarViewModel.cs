using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using OC_P5.Models;

namespace OC_P5.ViewModels
{
    public class CarViewModel
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
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? PurchaseDate { get; set; }

        [DataType(DataType.Currency)]
        public decimal? PurchasePrice { get; set; }

        public string? RepairDescription { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? RepairDate { get; set; }
        [DataType(DataType.Currency)]
        public decimal? RepairCost { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? SaleDate { get; set; }
        [DataType(DataType.Currency)]
        public decimal? SalePrice { get; set; }
        public List<IFormFile>? MediaFiles { get; set; }

        [BindNever]
        public int? YearOfProduction { get; set; }
        [BindNever]
        public string? BrandName { get; set; }
        [BindNever]
        public string? ModelName { get; set; }
        [BindNever]
        public string? TrimName { get; set; }
        [BindNever]
        public string? MediaPath { get; set; }
        [BindNever]
        public string? MediaLabel { get; set; }

        [BindNever]
        public IEnumerable<SelectListItem>? CarBrands { get; set; }
        [BindNever]
        public IEnumerable<SelectListItem>? CarModels { get; set; }
        [BindNever]
        public IEnumerable<SelectListItem>? CarTrims { get; set; }
        [BindNever]
        public IEnumerable<SelectListItem>? YearsOfProduction { get; set; }
    }
}
