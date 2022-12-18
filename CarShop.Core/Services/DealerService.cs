using CarShop.Core.Contracts;
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
    public class DealerService : IDealerService
    {
        private readonly IRepository repo;

        public DealerService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task Create(string userId, string phoneNumber)
        {
            var dealer = new Dealer()
            {
                UserId = userId,
                PhoneNumber = phoneNumber
            };

            await repo.AddAsync(dealer);
            await repo.SaveChangesAsync();
        }

        public async Task<bool> ExistsById(string userId)
        {
            return await repo.All<Dealer>()
                .AnyAsync(d => d.UserId == userId);
        }

        public async Task<bool> UserHasCars(string userId)
        {
            return await repo.All<Car>()
                .AnyAsync(c => c.BuyerId == userId);
        }

        public async Task<bool> UserWithPhoneNumberExists(string phoneNumber)
        {
            return await repo.All<Dealer>()
                .AnyAsync(d => d.PhoneNumber == phoneNumber);
        }
    }
}
