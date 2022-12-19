using CarShop.Core.Contracts;
using CarShop.Core.Models.Car;
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
    public class CarService : ICarService
    {
        private readonly IRepository repo;

        public CarService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<IEnumerable<CarCategoryModel>> AllCategories()
        {
            return await repo.AllReadonly<Category>()
                .OrderBy(c => c.Name)
                .Select(c => new CarCategoryModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<CarFuelModel>> AllFuels()
        {
            return await repo.AllReadonly<FuelType>()
                .OrderBy(c => c.Type)
                .Select(c => new CarFuelModel()
                {
                    Id = c.Id,
                    Type = c.Type
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<CarTransmissionModel>> AllTransmissions()
        {
            return await repo.AllReadonly<TransmissionType>()
                .OrderBy(c => c.Type)
                .Select(c => new CarTransmissionModel()
                {
                    Id = c.Id,
                    Type = c.Type
                })
                .ToListAsync();
        }

        public async Task<bool> CategoryExists(int categoryId)
        {
            return await repo.AllReadonly<Category>()
                .AnyAsync(c => c.Id == categoryId);
        }

        public async Task<bool> FuelExists(int fuelId)
        {
            return await repo.AllReadonly<FuelType>()
                .AnyAsync(c => c.Id == fuelId);
        }

        public async Task<bool> TransmissionExists(int transmissionId)
        {
            return await repo.AllReadonly<TransmissionType>()
                .AnyAsync(c => c.Id == transmissionId);
        }
        public async Task<int> CreateCar(CarModel model, int dealerId)
        {
            var car = new Car()
            {
                Make = model.Make,
                Model = model.Model,
                Description = model.Description,
                Colour = model.Colour,
                CategoryId = model.CategoryId,
                RegNumber = model.RegNumber,
                Year = model.Year,
                FuelId = model.FuelId,
                TransmissionId = model.TransmissionId,
                ImageUrl = model.ImageUrl,
                Price = model.Price,
                DealerId = dealerId
            };

            await repo.AddAsync(car);
            await repo.SaveChangesAsync();

            return car.Id;
        }

        public async Task<IEnumerable<CarHomeModel>> LastThreeCars()
        {
            return await repo.AllReadonly<Car>()
                .OrderByDescending(c => c.Id)
                .Select(c => new CarHomeModel() 
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    Year = c.Year,
                    ImageUrl = c.ImageUrl
                })
                .Take(3)
                .ToListAsync();
        }
    }
}
