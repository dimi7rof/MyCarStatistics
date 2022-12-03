using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyCarStatistics.Contracts;
using MyCarStatistics.Data.Models.Account;
using MyCarStatistics.Models;

namespace MyCarStatistics.Controllers
{
    public class CarController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ICarService carService;

        public CarController(UserManager<ApplicationUser> userManager, ICarService carService) 
        {
            this.userManager = userManager;
            this.carService = carService;
        }

        private async Task<bool> UserCanViewCar(int carId)
        {
            var user = await userManager.FindByNameAsync(User.Identity?.Name);
            return
                await userManager.IsInRoleAsync(user, "Admin") ||
                await carService.CheckUser(carId, user.Id);
        }

        [HttpPost]
        public async Task<IActionResult> Overview(int carId)
        {
            if (await UserCanViewCar(carId))
            {
                var carOverview = await carService.GetOverviewData(carId);
                return View(carOverview);
            }
            return RedirectToAction("AccessDenied", "Car");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CarViewModel car, int carId)
        {
            if (!ModelState.IsValid)
            {
                var entity = await carService.GetCarInfo(carId);
                return View(entity);
            }
            if (await UserCanViewCar(carId))
            {
                await carService.SaveCar(car);
                return RedirectToAction(nameof(All));
            }

            return RedirectToAction("AccessDenied", "Car");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int carId)
        {
            if (await UserCanViewCar(carId))
            {
                await carService.Delete(carId);
                return RedirectToAction(nameof(All));
            }

            return RedirectToAction("AccessDenied", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var user = await userManager.FindByNameAsync(User.Identity?.Name);
            var allCars = await carService.GetAll(user.Id);
            return View(allCars);
        }

        [HttpGet]
        public IActionResult AddCar()
        {
            var car = new CarViewModel();
            return View(car);
        }

        [HttpPost]
        public async Task<IActionResult> AddCar(CarViewModel car)
        {
            if (!ModelState.IsValid)
            {
                return View(car);
            }
            var user = await userManager.FindByNameAsync(User.Identity?.Name);
            await carService.Add(car, user.Id.ToString());

            return RedirectToAction(nameof(All));
        }
    }
}
