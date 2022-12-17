using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyCarStatistics.Contracts;
using MyCarStatistics.Data.Models.Account;
using MyCarStatistics.Models;

namespace MyCarStatistics.Controllers
{
    public class RepairController : BaseController
    {
        private readonly IRepairService repairService;

        public RepairController(
            UserManager<ApplicationUser> userManager,
            IRepairService repairService,
            IUserService userService)
            : base(userManager, userService)
        {
            this.repairService = repairService;
        }

        [HttpGet]
        public async Task<IActionResult> Add(int carId)
        {
            if (await UserHasRights(carId))
            {
                var model = await repairService.GetCar(carId);
                return View(model);
            }
            return RedirectToAction("AccessDenied", "Home");           
        }

        [HttpPost]
        public async Task<IActionResult> Add(RepairViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await repairService.AddService(model);
            return RedirectToAction(nameof(All), model.CarId);
        }

        [HttpGet]
        public async Task<IActionResult> All(int carId)
        {
            if (await UserHasRights(carId))
            {
                var all = await repairService.GerRepairs(carId);
                ViewBag.Id = carId;
                return View(all);
            }
            return RedirectToAction("AccessDenied", "Home");            
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int serviceId)
        {
            var carId = await repairService.Delete(serviceId);
            return RedirectToAction(nameof(All), carId);
        }
    }
}
