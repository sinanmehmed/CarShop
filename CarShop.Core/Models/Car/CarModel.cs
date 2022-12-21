using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Core.Models.Car
{
    public class CarModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Make { get; set; } = null!;

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Model { get; set; } = null!;

        [Required]
        [StringLength(500, MinimumLength = 20)]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Colour { get; set; } = null!;

        [Required]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Display(Name = "Price")]
        [Range(0.00, 20000000.00, ErrorMessage = "Price must be a positive number and less than {2} leva")]
        public decimal Price { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(10)]
        public string RegNumber { get; set; } = null!;

        [Required]
        [Range(1910, 2022)]
        public int Year { get; set; }

        [Required]
        [Display(Name = "Cubic cm")]
        [Range(0, 10000)]
        public int EngineSize { get; set; }

        [Required]
        [Range(0, 1500)]
        public int HorsePower { get; set; }

        [Display(Name = "Fuel")]
        public int FuelId { get; set; }

        [Display(Name = "Transmission")]
        public int TransmissionId { get; set; }

        public IEnumerable<CarCategoryModel> CarCategories { get; set; } = new List<CarCategoryModel>();
        public IEnumerable<CarFuelModel> CarFuels { get; set; } = new List<CarFuelModel>();
        public IEnumerable<CarTransmissionModel> CarTransmissions { get; set; } = new List<CarTransmissionModel>();

    }
}
