using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using OC_P5.Models;
using System.ComponentModel.DataAnnotations;

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
        [DisplayFormat(DataFormatString = "{0:N2} €", ApplyFormatInEditMode = true)]
        public DateTime? PurchaseDate { get; set; }

        [RegularExpression(@"^\d{1,3}(?:[ ]?\d{3})*(?:[,.]\d{1,2})?$", ErrorMessage = "Le prix doit être un nombre valide.")]
        public decimal? PurchasePrice { get; set; }

        public string? RepairDescription { get; set; }
        public DateTime? RepairDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2} €", ApplyFormatInEditMode = true)]
        public decimal? RepairCost { get; set; }
        public DateTime? SaleDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2} €", ApplyFormatInEditMode = true)]
        public decimal? SalePrice { get; set; }
        public List<IFormFile>? MediaFiles { get; set; }

        [BindNever]
        public int YearOfProduction { get; set; }
        [BindNever]
        public string BrandName { get; set; }
        [BindNever]
        public string ModelName { get; set; }
        [BindNever]
        public string TrimName { get; set; }
        [BindNever]
        public string MediaPath { get; set; }
        [BindNever]
        public string MediaLabel { get; set; }

        public IEnumerable<SelectListItem> CarBrands { get; set; }
        public IEnumerable<SelectListItem> CarModels { get; set; }
        public IEnumerable<SelectListItem> CarTrims { get; set; }
        public IEnumerable<SelectListItem> YearsOfProduction { get; set; }
    }
}
