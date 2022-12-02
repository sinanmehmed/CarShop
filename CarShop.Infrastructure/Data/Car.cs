using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Infrastructure.Data
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Make { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string Model { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string Colour { get; set; } = null!;

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        [Required]
        [StringLength(10)]
        public string RegNumber { get; set; } = null!;

        [Required]
        [Range(1910, 2022)]
        public int Year { get; set; }

        [Required]
        [StringLength(50)]
        public string EngineId { get; set; } = null!;

        [Required]
        [Display(Name = "Cubic cm")]
        [Range(0, 10000)]
        public int EngineSize { get; set; }

        [Required]
        [Range(0, 1500)]
        public int HorsePower { get; set; }

        [Required]
        public FuelType FuelType { get; set; }

        [Required]
        public TransmissionType TransmissionType { get; set; }

        [Required]
        [StringLength(200)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Column(TypeName = "money")]
        [Precision(18, 2)]
        public decimal Price { get; set; }

        [Required]
        public int DealerId { get; set; }

        [ForeignKey(nameof(DealerId))]
        public Dealer Dealer { get; set; }

        public string? BuyerId { get; set; }

        [ForeignKey(nameof(BuyerId))]
        public ApplicationUser? Buyer { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
