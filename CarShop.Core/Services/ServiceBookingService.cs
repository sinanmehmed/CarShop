using CarShop.Core.Contracts;
using CarShop.Core.Models.Car;
using CarShop.Core.Models.ServiceBooking;
using CarShop.Infrastructure.Data;
using CarShop.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Core.Services
{
    public class ServiceBookingService : IServiceBookingService
    {
        private readonly IRepository repo;
        public ServiceBookingService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<IEnumerable<CarServiceModel>> AllCarsByUserId(string userId)
        {
            return await repo.AllReadonly<Car>()
                .Where(c => c.BuyerId == userId)
                .Where(c => c.IsActive)
                .Select(c => new CarServiceModel()
                {
                    Make = c.Make,
                    Id = c.Id,
                    ImageUrl = c.ImageUrl,
                    IsBought = c.BuyerId != null,
                    Price = c.Price,
                    Model = c.Model
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<ServiceBookingGarageModel>> AllGarages()
        {
            return await repo.AllReadonly<Garage>()
                .OrderBy(g => g.GarageName)
                .Select(g => new ServiceBookingGarageModel()
                {
                    Id = g.Id,
                    GarageName = g.GarageName
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<ServiceBookingMechanicModel>> AllMechanics()
        {
            return await repo.AllReadonly<Mechanic>()
                .OrderBy(m => m.FirstName)
                .Select(m => new ServiceBookingMechanicModel()
                {
                    Id = m.Id,
                    FirstName = m.FirstName,
                    LastName = m.LastName,
                    Rating = m.Rating
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<ServiceBookingNameModel>> AllServices()
        {
            return await repo.AllReadonly<Service>()
                .OrderBy(s => s.ServiceName)
                .Select(c => new ServiceBookingNameModel()
                {
                    Id = c.Id,
                    ServiceName = c.ServiceName + " - " + c.Price + " BGN"
                })
                .ToListAsync();
        }

        public async Task<bool> IsBought(int carId)
        {
            return (await repo.GetByIdAsync<Car>(carId)).BuyerId != null;
        }

        public async Task<bool> IsBoughtByUserId(int carId, string currentUserId)
        {
            bool result = false;
            var car = await repo.AllReadonly<Car>()
                .Where(c => c.IsActive)
                .Where(c => c.Id == carId)
                .FirstOrDefaultAsync();

            if (car != null && car.BuyerId == currentUserId)
            {
                result = true;
            }

            return result;
        }

        public async Task<int> RequestService(ServiceBookingModel model, string userId)
        {
            var booking = new ServiceBooking()
            {
                Id = model.Id,
                CarId = model.CarId,
                UserId = model.UserId,
                GarageId = model.GarageId,
                MechanicId= model.MechanicId,
                ServiceId = model.ServiceId,
                Date = model.Date,
                Comment = model.Comment,
                Status = model.Status
            };

            await repo.AddAsync(booking);
            await repo.SaveChangesAsync();

            return booking.Id;
        }
    }
}
