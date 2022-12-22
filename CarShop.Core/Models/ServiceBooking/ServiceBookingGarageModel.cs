using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Core.Models.ServiceBooking
{
    public class ServiceBookingGarageModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string GarageName { get; set; } = null!;
    }
}
