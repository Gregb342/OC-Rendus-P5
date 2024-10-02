﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
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

        public DateTime? PurchaseDate { get; set; }
        public decimal? PurchasePrice { get; set; }

        public string? RepairDescription { get; set; }
        public DateTime? RepairDate { get; set; }
        public decimal? RepairCost { get; set; }
        public DateTime? SaleDate { get; set; }
        public decimal? SalePrice { get; set; }
        public List<IFormFile>? MediaFiles { get; set; }

        [BindNever]
        public int YearOfProduction { get; set; }
        // TODO : Régler le probleme de dependance fortes des noms de brand/model/trim dans le controller
        //[BindNever]
        //public string CarBrandName { get; set; }
        //[BindNever]
        //public string CarModelName { get; set; }
        //[BindNever]
        //public string CarTrimName { get; set; }
    }
}
