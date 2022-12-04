using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyCarStatistics.Contracts;
using MyCarStatistics.Data.Models.Account;
using MyCarStatistics.Models;

namespace MyCarStatistics.Controllers
{
    public class RefuelController : BaseController
    {        
        private readonly IRefuelService refuelService;        

        public RefuelController(
            UserManager<ApplicationUser> userManager,
            IRefuelService refuelService,
            IUserService userService)
            : base(userManager, userService)
        {
            this.refuelService = refuelService;
        }

        [HttpGet]
        public async Task<IActionResult> Add(int carId)
        {
            if (await UserHasRights(carId))
            {
                var model = await refuelService.GetCar(carId);
                TempData["carId"] = carId;
                return View(model);
            }
            return RedirectToAction("AccessDenied", "Home");            
        }

        [HttpPost]
        public async Task<IActionResult> Add(RefuelViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await refuelService.AddRefuel(model);
            return RedirectToAction(nameof(All), TempData["carId"]);
        }

        [HttpGet]
        public async Task<IActionResult> All(int carId)
        {
            if (carId == 0)
            {
                carId = (int)TempData["carId"];
            }
            if (await UserHasRights(carId))
            {
                var allRefuels = await refuelService.GetRefuels(carId);
                ViewBag.Id = carId;
                TempData["carId"] = carId;
                return View(allRefuels);
            }
            return RedirectToAction("AccessDenied", "Home");            
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int refId)
        {           
            var carId = await refuelService.Delete(refId);
            return RedirectToAction(nameof(All), carId);
        }
    }
}
