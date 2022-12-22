using CarShop.Core.Models.Car;
using CarShop.Core.Models.ServiceBooking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Core.Contracts
{
    public interface IServiceBookingService
    {
        Task<IEnumerable<ServiceBookingNameModel>> AllServices();
    }
}
