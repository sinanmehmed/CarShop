using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Infrastructure.Data
{
    public class Engine
    {
        [Required]
        public int EngineId { get; set; }

        [Required]
        [Display(Name = "Cubic cm")]
        [Range(0, 10000)]
        public int Size { get; set; }

        [Required]
        [Range(0, 1400)]
        public int HorsePower { get; set; }

        [Required]
        public FuelType FuelType { get; set; }

        [Required]
        public TransmissionType TransmissionType { get; set; }
    }
}
