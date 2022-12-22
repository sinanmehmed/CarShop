using CarShop.Core.Contracts;
using CarShop.Core.Models.Car;
using CarShop.Extensions;
using CarShop.Infrastructure.Data;
using CarShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery] AllCarsQueryModel query)
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
            IEnumerable<CarServiceModel> myCars;
            var userId = User.Id();

            if (await dealerService.ExistsById(userId))
            {
                int dealerId = await dealerService.GetDealerId(userId);
                myCars = await carService.AllCarsByDealerId(dealerId);
            }
            else
            {
                myCars = await carService.AllCarsByUserId(userId);
            }

            return View(myCars);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            if (await carService.Exists(id) == false)
            {
                return RedirectToAction(nameof(All));
            }

            var model = await carService.CarDetailsById(id);


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
        public async Task<IActionResult> Add(CarModel carModel)
        {
            if ((await dealerService.ExistsById(User.Id())) == false)
            {
                return RedirectToAction(nameof(DealerController.Become), " Dealer");
            }

            if ((await carService.CategoryExists(carModel.CategoryId)) == false)
            {
                ModelState.AddModelError(nameof(carModel.CategoryId), "Category does not exist");
            }

            if ((await carService.FuelExists(carModel.FuelId)) == false)
            {
                ModelState.AddModelError(nameof(carModel.FuelId), "Fuel does not exist");
            }

            if ((await carService.TransmissionExists(carModel.TransmissionId)) == false)
            {
                ModelState.AddModelError(nameof(carModel.TransmissionId), "Transmission does not exist");
            }

            if (!ModelState.IsValid)
            {
                carModel.CarCategories = await carService.AllCategories();
                carModel.CarFuels = await carService.AllFuels();
                carModel.CarTransmissions = await carService.AllTransmissions();
                return View(carModel);
            }

            int dealerId = await dealerService.GetDealerId(User.Id());

            int id = await carService.CreateCar(carModel, dealerId);

            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if ((await carService.Exists(id) == false))
            {
                return RedirectToAction(nameof(All));
            }

            if ((await carService.HasDealerWithId(id, User.Id())) == false)
            {
                //logger.LogInformation("User with id {0} attempted to open other agent house", User.Id());

                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            var car = await carService.CarDetailsById(id);
            var categoryId = await carService.GetCarCategoryId(id);
            var fuelId = await carService.GetCarFuelId(id);
            var transmissionId = await carService.GetCarTransmissionId(id);


            var model = new CarModel()
            {
                Id = id,
                Make = car.Make,
                Model = car.Model,
                Colour = car.Colour,
                RegNumber = car.RegNumber,
                Year = car.Year,
                EngineSize = car.EngineSize,
                HorsePower = car.HorsePower,
                FuelId = fuelId,
                TransmissionId = transmissionId,
                CategoryId = categoryId,
                Description = car.Description,
                ImageUrl = car.ImageUrl,
                Price = car.Price,
                CarCategories = await carService.AllCategories(),
                CarFuels = await carService.AllFuels(),
                CarTransmissions = await carService.AllTransmissions()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CarModel carModel)
        {
            if (id != carModel.Id)
            {
                return RedirectToAction("/Account/AccessDenied", new { area = "Identity" });
            }

            if ((await carService.Exists(carModel.Id)) == false)
            {
                ModelState.AddModelError("", "The car does not exist!");
                carModel.CarCategories = await carService.AllCategories();

                return View(carModel);
            }

            if ((await carService.HasDealerWithId(carModel.Id, User.Id())) == false)
            {
                return RedirectToAction("/Account/AccessDenied", new { area = "Identity" });
            }

            if ((await carService.CategoryExists(carModel.CategoryId)) == false)
            {
                ModelState.AddModelError(nameof(carModel.CategoryId), "Category does not exist!");
                carModel.CarCategories = await carService.AllCategories();

                return View(carModel);
            }

            if (ModelState.IsValid == false)
            {
                carModel.CarCategories = await carService.AllCategories();

                return View(carModel);
            }

            await carService.Edit(carModel.Id, carModel);

            return RedirectToAction(nameof(Details), new { carModel.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if ((await carService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            if ((await carService.HasDealerWithId(id, User.Id())) == false)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            var car = await carService.CarDetailsById(id);
            var model = new CarDetailsViewModel()
            {
                Make = car.Make,
                ImageUrl = car.ImageUrl,
                Model = car.Model
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, CarDetailsViewModel model)
        {
            if ((await carService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            if ((await carService.HasDealerWithId(id, User.Id())) == false)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            await carService.Delete(id);

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Buy(int id)
        {
            if ((await carService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }
            if ((await carService.HasDealerWithId(id, User.Id())) == false)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            if (/*!User.IsInRole(AdminRolleName) && */await dealerService.ExistsById(User.Id()))
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            if (await carService.IsBought(id))
            {
                return RedirectToAction(nameof(All));
            }

            await carService.Buy(id, User.Id());

            return RedirectToAction(nameof(Mine));
        }

        [HttpPost]
        public async Task<IActionResult> Sell(int id)
        {
            if ((await carService.Exists(id)) == false ||
                            (await carService.IsBought(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            if ((await carService.IsBoughtByUserId(id, User.Id())) == false)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            await carService.Sell(id);

            return RedirectToAction(nameof(Mine));
        }
    }
}
