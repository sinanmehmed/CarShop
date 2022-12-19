﻿using CarShop.Core.Models.Car;
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

    }
}
