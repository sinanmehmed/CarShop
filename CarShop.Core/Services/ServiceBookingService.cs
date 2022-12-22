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
    }
}
