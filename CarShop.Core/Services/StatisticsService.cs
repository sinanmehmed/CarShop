using CarShop.Core.Contracts;
using CarShop.Core.Models.Statistics;
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
    public class StatisticsService : IStatisticsService
    {
        private readonly IRepository repo;

        public StatisticsService(IRepository _repo)
        {
            repo = _repo;
        }
        public async Task<StatisticsServiceModel> Total()
        {
            int totalCars = await repo.AllReadonly<Car>()
                .CountAsync(c => c.IsActive);
            int boughtCars = await repo.AllReadonly<Car>()
                .CountAsync(c => c.IsActive && c.BuyerId != null);

            return new StatisticsServiceModel()
            {
                TotalCars = totalCars,
                TotalSales = boughtCars
            };
        }
    }
}
