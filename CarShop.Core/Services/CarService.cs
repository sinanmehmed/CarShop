using CarShop.Core.Contracts;
using CarShop.Core.Exceptions;
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

        private readonly IGuard guard;

        public CarService(
            IRepository _repo,
            IGuard _guard)
        {
            repo = _repo;
            guard = _guard;
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
                .Where(c => c.IsActive)
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

        public async Task<CarsQueryModel> All(string? category = null, string? searchTerm = null, CarSorting sorting = CarSorting.Newest, int currentPage = 1, int carsPerPage = 1)
        {
            var result = new CarsQueryModel();
            var cars = repo.AllReadonly<Car>();

            if (string.IsNullOrEmpty(category) == false)
            {
                cars = cars.Where(c => c.Category.Name == category);
            }

            if (string.IsNullOrEmpty(searchTerm) == false)
            {
                searchTerm = $"%{searchTerm.ToLower()}%";

                cars = cars
                    .Where(h => EF.Functions.Like(h.Make.ToLower(), searchTerm) ||
                        EF.Functions.Like(h.Model.ToLower(), searchTerm) ||
                        EF.Functions.Like(h.Description.ToLower(), searchTerm));
            }

            cars = sorting switch
            {
                CarSorting.Price => cars
                    .OrderBy(c => c.Price),
                CarSorting.NotBoughtFirst => cars
                    .OrderBy(h => h.BuyerId),
                _ => cars.OrderByDescending(c => c.Id)
            };

            result.Cars = await cars
                .Skip((currentPage - 1) * carsPerPage)
                .Take(carsPerPage)
                .Select(c => new CarServiceModel()
                {
                    Make = c.Make,
                    Model =c.Model,
                    Id = c.Id,
                    ImageUrl = c.ImageUrl,
                    IsBought = c.BuyerId != null,
                    Price = c.Price
                    
                })
                .ToListAsync();

            result.TotalCarsCount = await cars.CountAsync();

            return result;
        }

        public async Task<IEnumerable<string>> AllCategoriesNames()
        {
            return await repo.AllReadonly<Category>()
                .Select(c => c.Name)
                .Distinct()
                .ToListAsync();
        }

        public async Task<IEnumerable<CarServiceModel>> AllCarsByDealerId(int id)
        {
            return await repo.AllReadonly<Car>()
                .Where(c => c.IsActive)
                .Where(c => c.DealerId == id)
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

        public async Task<CarDetailsModel> CarDetailsById(int id)
        {
            return await repo.AllReadonly<Car>()
                .Where(c => c.IsActive)
                .Where(c => c.Id == id)
                .Select(c => new CarDetailsModel()
                {
                    Make = c.Make,
                    Category = c.Category.Name,
                    Description = c.Description,
                    Colour = c.Colour,
                    RegNumber = c.RegNumber,
                    Year = c.Year,
                    EngineSize = c.EngineSize,
                    HorsePower = c.HorsePower,
                    Fuel = c.Fuel.Type,
                    Transmission = c.Transmission.Type,
                    Id = id,
                    ImageUrl = c.ImageUrl,
                    IsBought = c.BuyerId != null,
                    Price = c.Price,
                    Model = c.Model,
                    Dealer = new Models.Dealer.DealerServiceModel()
                    {
                        Email = c.Dealer.User.Email,
                        PhoneNumber = c.Dealer.PhoneNumber
                    }
                })
                .FirstAsync();
        }

        public async Task<bool> Exists(int id)
        {
            return await repo.AllReadonly<Car>()
                .AnyAsync(c => c.Id == id && c.IsActive); 
        }

        public async Task Edit(int carId, CarModel model)
        {
            var car = await repo.GetByIdAsync<Car>(carId);

            car.Make = model.Make;
            car.Model = model.Model;
            car.Description = model.Description;
            car.ImageUrl = model.ImageUrl;
            car.Year = model.Year;
            car.Price = model.Price;
            car.CategoryId = model.CategoryId;
            car.FuelId = model.FuelId;
            car.TransmissionId = model.TransmissionId;
            car.RegNumber = model.RegNumber;
            car.Colour = model.Colour;
            car.EngineSize = model.EngineSize;
            car.HorsePower = model.HorsePower;

            await repo.SaveChangesAsync();
        }

        public async Task<bool> HasDealerWithId(int carId, string currentUserId)
        {
            bool result = false;
            var car = await repo.AllReadonly<Car>()
                .Where(c => c.IsActive)
                .Where(c => c.Id == carId)
                .Include(c => c.Dealer)
                .FirstOrDefaultAsync();

            if (car?.Dealer != null && car.Dealer.UserId == currentUserId)
            {
                result = true;
            }

            return result;
        }

        public async Task<int> GetCarCategoryId(int carId)
        {
            return (await repo.GetByIdAsync<Car>(carId)).CategoryId;
        }

        public async Task Delete(int carId)
        {
            var car = await repo.GetByIdAsync<Car>(carId);
            car.IsActive = false;

            await repo.SaveChangesAsync();
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

        public async Task Buy(int carId, string currentUserId)
        {
            var car = await repo.GetByIdAsync<Car>(carId);

            if (car != null && car.BuyerId != null)
            {
                throw new ArgumentException("Car was already bought");
            }

            guard.AgainstNull(car, "Car can not be found");
            car.BuyerId = currentUserId;

            await repo.SaveChangesAsync();
        }

        public async Task Sell(int carId)
        {
            var car = await repo.GetByIdAsync<Car>(carId);
            guard.AgainstNull(car, "Car can not be found");
            car.BuyerId = null;

            await repo.SaveChangesAsync();
        }

        public async Task<int> GetCarFuelId(int carId)
        {
            return (await repo.GetByIdAsync<Car>(carId)).FuelId;
        }

        public async Task<int> GetCarTransmissionId(int carId)
        {
            return (await repo.GetByIdAsync<Car>(carId)).TransmissionId;
        }
    }
}
