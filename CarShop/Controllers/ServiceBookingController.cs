using CarShop.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CarShop.Controllers
{
    public class ServiceBookingController : Controller
    {
        private readonly IServiceBookingService bookingService;

        private readonly ICarService carService;

        public ServiceBookingController(
            IServiceBookingService _bookingService,
            ICarService _carService)
        {
            bookingService = _bookingService;
            carService = _carService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
