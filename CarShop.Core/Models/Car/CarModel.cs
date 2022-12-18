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

        [Display(Name = "Fuel")]
        public int FuelId { get; set; }

        [Display(Name = "Transmission")]
        public int TransmissionId { get; set; }

        public IEnumerable<CarCategoryModel> CarCategories { get; set; } = new List<CarCategoryModel>();
        public IEnumerable<CarFuelModel> CarFuels { get; set; } = new List<CarFuelModel>();
        public IEnumerable<CarTransmissionModel> CarTransmissions { get; set; } = new List<CarTransmissionModel>();

    }
}
