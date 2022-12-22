using CarShop.Core.Models.Car;
using CarShop.Core.Models.ServiceBooking;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Core.Contracts
{
    public interface IServiceBookingService
    {
        Task<IEnumerable<ServiceBookingNameModel>> AllServices();

        
        Task<IEnumerable<ServiceBookingCarModel>> AllCarsByUserId(string userId);

        Task<IEnumerable<ServiceBookingMechanicModel>> AllMechanics();

        Task<IEnumerable<ServiceBookingGarageModel>> AllGarages();

        Task<bool> IsBought(int carId);

        Task<bool> IsBoughtByUserId(int carId, string currentUserId);

        Task<int> RequestService(ServiceBookingModel model, string userId);
    }
}
