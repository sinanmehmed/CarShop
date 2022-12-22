using CarShop.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarShop.Core.Models.Car;

namespace CarShop.Core.Models.ServiceBooking
{
    public class ServiceBookingModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CarId { get; set; }
                
        [Required]
        public string UserId { get; set; } = null!;

        
        [Required]
        public int GarageId { get; set; }

        
        public int? MechanicId { get; set; }



        [Required]
        public int ServiceId { get; set; }

        
        [Required]
        public DateTime Date { get; set; }

        public string? Comment { get; set; }

        [Required]
        public ServiceBookingStatus Status { get; set; } = ServiceBookingStatus.Pending;

        public IEnumerable<ServiceBookingNameModel> ServiceBookingNames { get; set; } = new List<ServiceBookingNameModel>();

        public IEnumerable<ServiceBookingMechanicModel> ServiceBookingMechanics { get; set; } = new List<ServiceBookingMechanicModel>();

        public IEnumerable<ServiceBookingGarageModel> ServiceBookingGarages { get; set; } = new List<ServiceBookingGarageModel>();
    }
}
