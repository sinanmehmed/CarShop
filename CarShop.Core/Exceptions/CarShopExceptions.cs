using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Core.Exceptions
{
    public class CarShopExceptions : ApplicationException
    {
        public CarShopExceptions()
        {

        }

        public CarShopExceptions(string errorMessage)
            : base(errorMessage)
        {

        }
    }
}
