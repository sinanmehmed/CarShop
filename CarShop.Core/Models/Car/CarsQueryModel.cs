using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Core.Models.Car
{
    public class CarsQueryModel
    {
        public int TotalCarsCount { get; set; }

        public IEnumerable<CarServiceModel> Cars { get; set; } = new List<CarServiceModel>();
    }
}
