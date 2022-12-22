using CarShop.Core.Models.Dealer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Core.Models.Car
{
    public class CarDetailsModel : CarServiceModel
    {
        public string Description { get; set; } = null!;

        public string Category { get; set; } = null!;

        public string Colour { get; set; }

        public string RegNumber { get; set; }

        public int Year { get; set; }

        public int EngineSize { get; set; }

        public int HorsePower { get; set; }

        public string Fuel { get; set; }

        public string Transmission { get; set; }
        public DealerServiceModel Dealer { get; internal set; }
    }
}
