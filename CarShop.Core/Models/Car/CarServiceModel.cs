using CarShop.Core.Contracts;
using System.ComponentModel.DataAnnotations;

namespace CarShop.Core.Models.Car
{
    public class CarServiceModel 
    {
        public int Id { get; init; }

        public string Make { get; init; } = null!;

        public string Model { get; init; } = null!;

        [Display(Name = "Image URL")]
        public string ImageUrl { get; init; } = null!;

        [Display(Name = "Price")]
        public decimal Price { get; init; }

        [Display(Name = "Is Bought")]
        public bool IsBought { get; init; }
    }
}
