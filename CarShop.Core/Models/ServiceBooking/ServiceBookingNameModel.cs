using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Core.Models.ServiceBooking
{
    public class ServiceBookingNameModel
    {
        public int Id { get; set; }

        public string ServiceName { get; set; } = null!;

        [Precision(18, 2)]
        public decimal Price { get; set; }
    }
}
