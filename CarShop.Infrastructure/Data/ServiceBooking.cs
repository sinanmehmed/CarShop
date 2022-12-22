using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Infrastructure.Data
{
    public class ServiceBooking
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CarId { get; set; }

        [Required]
        [ForeignKey(nameof(CarId))]
        public Car Car { get; set; } = null!;

        [Required]
        public string UserId { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;

        [Required]
        public int GarageId { get; set; }

        [Required]
        [ForeignKey(nameof(GarageId))]
        public Garage Garage { get; set; } = null!;

        
        public int? MechanicId { get; set; }

        
        [ForeignKey(nameof(MechanicId))]
        public Mechanic? Mechanic { get; set; } = null!;

        [Required]
        public int ServiceId { get; set; }

        [ForeignKey(nameof(ServiceId))]
        public Service Service { get; set; } = null!;

        [Required]
        public DateTime Date { get; set; }

        public string? Comment { get; set; }

        [Required]
        public ServiceBookingStatus Status { get; set; } = ServiceBookingStatus.Pending;

    }
}
