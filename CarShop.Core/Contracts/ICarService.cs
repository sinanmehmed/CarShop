using CarShop.Core.Models.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Core.Contracts
{
    public interface ICarService
    {
        Task<IEnumerable<CarHomeModel>> LastThreeCars();

        Task<IEnumerable<CarCategoryModel>> AllCategories();

        Task<IEnumerable<CarFuelModel>> AllFuels();

        Task<IEnumerable<CarTransmissionModel>> AllTransmissions();

        Task<bool> CategoryExists(int categoryId);

        Task<int> CreateCar(CarModel model, int dealerId);

        Task<bool> FuelExists(int fuelId);

        Task<bool> TransmissionExists(int transmissionId);

        Task<CarsQueryModel> All(
            string? category = null,
            string? searchTerm = null,
            CarSorting sorting = CarSorting.Newest,
            int currentPage = 1,
            int carsPerPage = 1);

        Task<IEnumerable<string>> AllCategoriesNames();

        Task<IEnumerable<CarServiceModel>> AllCarsByDealerId(int id);

        Task<IEnumerable<CarServiceModel>> AllCarsByUserId(string userId);

        Task<CarDetailsModel> CarDetailsById(int id);

        Task<bool> Exists(int id);

        Task Edit(int carId, CarModel model);

        Task<bool> HasDealerWithId(int carId, string currentUserId);

        Task<int> GetCarCategoryId(int carId);

        Task Delete(int carId);

    }
}
