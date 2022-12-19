using CarShop.Core.Constants;
using CarShop.Core.Contracts;
using CarShop.Core.Models.Dealer;
using CarShop.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarShop.Controllers
{
    [Authorize]
    public class DealerController : Controller
    {
        private readonly IDealerService dealerService;


        public DealerController(IDealerService _dealerService)
        {
            dealerService = _dealerService;
        }

        [HttpGet]
        public async Task<IActionResult> Become()
        {

            if (await dealerService.ExistsById(User.Id()))
            {
                TempData[MessageConstant.ErrorMessage] = "You are already a Dealer!";

                return RedirectToAction("Index", "Home");
            }

            var model = new BecomeDealerModel();
            

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Become(BecomeDealerModel model)
        {
            var userId = User.Id();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await dealerService.ExistsById(userId))
            {
                TempData[MessageConstant.ErrorMessage] = "You are already a Dealer!";

                return RedirectToAction("Index", "Home");
            }

            if (await dealerService.UserWithPhoneNumberExists(model.PhoneNumber))
            {
                TempData[MessageConstant.ErrorMessage] = "The entered Phone Number already exists!";

                return RedirectToAction("Index", "Home");
            }

            if (await dealerService.UserHasCars(userId))
            {
                TempData[MessageConstant.ErrorMessage] = "You can't own cars from us if you want to become a Dealer!";

                return RedirectToAction("Index", "Home");
            }

            await dealerService.Create(userId, model.PhoneNumber);

            return RedirectToAction("All", "Car");
        }
    }
}
