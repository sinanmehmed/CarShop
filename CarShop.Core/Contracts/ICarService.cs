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

    }
}
