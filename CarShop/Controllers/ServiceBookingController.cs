using CarShop.Core.Contracts;
using CarShop.Core.Models.Car;
using CarShop.Core.Models.ServiceBooking;
using CarShop.Core.Services;
using CarShop.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarShop.Controllers
{
    [Authorize]
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

        [HttpGet]
        public async Task<IActionResult> RequestBooking()
        {

            if ((await bookingService.AllCarsByUserId(User.Id()) == null))
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            var model = new ServiceBookingModel()
            {
                ServiceBookingNames = await bookingService.AllServices(),
                ServiceBookingMechanics = await bookingService.AllMechanics(),
                ServiceBookingGarages = await bookingService.AllGarages(),
                ServiceBookingCars = await bookingService.AllCarsByUserId(User.Id()),

            };
            return View(model);
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
