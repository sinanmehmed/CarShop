using CarShop.Core.Models.Dealer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarShop.Controllers
{
    [Authorize]
    public class DealerController : Controller
    {
        [HttpGet]
        public IActionResult Become()
        {
            return View();
        }

        public async Task<IActionResult> Become(BecomeDealerModel model)
        {
            return RedirectToAction("All", "Car");
        }
    }
}
