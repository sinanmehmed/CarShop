﻿using CarShop.Core.Contracts;
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
        public async Task<IActionResult> Add(CarModel model)
        {
            if ((await dealerService.ExistsById(User.Id())) == false)
            {
                return RedirectToAction(nameof(DealerController.Become), " Dealer");
            }

            if ((await carService.CategoryExists(model.CategoryId)) == false)
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

            var model = new CarModel()
            {
                Id = id,
                Make = car.Make,
                Model = car.Model,
                CategoryId = categoryId,
                Description = car.Description,
                ImageUrl = car.ImageUrl,
                Price = car.Price,
                CarCategories = await carService.AllCategories()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CarModel model)
        {
            if ((await carService.Exists(model.Id)) == false)
            {
                ModelState.AddModelError("", "The car does not exist!");
                model.CarCategories = await carService.AllCategories();

                return View(model);
            }

            if ((await carService.HasDealerWithId(model.Id, User.Id())) == false)
            {
                return RedirectToAction("/Account/AccessDenied", new { area = "Identity" });
            }

            if ((await carService.CategoryExists(model.CategoryId)) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist!");
                model.CarCategories = await carService.AllCategories();

                return View(model);
            }

            if (ModelState.IsValid == false)
            {
                model.CarCategories = await carService.AllCategories();

                return View(model);
            }

            await carService.Edit(model.Id, model);

            return RedirectToAction(nameof(Details), new { model.Id });
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
