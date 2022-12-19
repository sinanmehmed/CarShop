using CarShop.Core.Contracts;
using CarShop.Core.Models.Car;
using CarShop.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarShop.Controllers
{
    [Authorize]
    public class CarController : Controller
    {
        private readonly ICarService carService;

        private readonly IDealerService dealerService;

        public CarController(
            ICarService _carService,
            IDealerService _dealerService)
        {
            carService = _carService;
            dealerService = _dealerService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            var model = new CarsQueryModel();

            return View(model);
        }

        public async Task<IActionResult> Mine()
        {
            var model = new CarsQueryModel();

            return View(model);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var model = new CarDetailsModel();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {

            if ((await dealerService.ExistsById(User.Id())) == false)
            {
                return RedirectToAction(nameof(DealerController.Become), " Dealer");
            }

            var model = new CarModel()
            {
                CarCategories = await carService.AllCategories(),
                CarFuels = await carService.AllFuels(),
                CarTransmissions = await carService.AllTransmissions()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CarModel model)
        {
            int id = 1;

            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = new CarModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CarModel model)
        {
            
            return RedirectToAction(nameof(Details), new { id });
        }

        
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Buy(int id)
        {

            return RedirectToAction(nameof(Mine));
        }

        [HttpPost]
        public async Task<IActionResult> Sell(int id)
        {

            return RedirectToAction(nameof(Mine));
        }
    }
}
