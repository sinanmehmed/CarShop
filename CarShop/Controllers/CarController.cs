using CarShop.Core.Contracts;
using CarShop.Core.Models.Car;
using CarShop.Extensions;
using CarShop.Models;
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
        public async Task<IActionResult> All([FromQuery]AllCarsQueryModel query)
        {
            var result = await carService.All(
                query.Category,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                AllCarsQueryModel.CarsPerPage);

            query.TotalCarsCount = result.TotalCarsCount;
            query.Categories = await carService.AllCategoriesNames();
            query.Cars = result.Cars;

            return View(query);
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
            if ((await dealerService.ExistsById(User.Id())) == false)
            {
                return RedirectToAction(nameof(DealerController.Become), " Dealer");
            }

            if((await carService.CategoryExists(model.CategoryId)) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist");
            }

            if ((await carService.FuelExists(model.FuelId)) == false)
            {
                ModelState.AddModelError(nameof(model.FuelId), "Fuel does not exist");
            }

            if ((await carService.TransmissionExists(model.TransmissionId)) == false)
            {
                ModelState.AddModelError(nameof(model.TransmissionId), "Transmission does not exist");
            }

            if (!ModelState.IsValid)
            {
                model.CarCategories = await carService.AllCategories();
                model.CarFuels = await carService.AllFuels();
                model.CarTransmissions = await carService.AllTransmissions();
                return View(model);
            }

            int dealerId = await dealerService.GetDealerId(User.Id());

            int id = await carService.CreateCar(model, dealerId);

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
