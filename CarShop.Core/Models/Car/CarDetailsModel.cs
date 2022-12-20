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
        public DealerServiceModel Dealer { get; internal set; }
    }
}
