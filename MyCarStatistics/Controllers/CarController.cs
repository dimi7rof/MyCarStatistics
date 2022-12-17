using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyCarStatistics.Contracts;
using MyCarStatistics.Data.Models;
using MyCarStatistics.Data.Models.Account;
using MyCarStatistics.Models;

namespace MyCarStatistics.Controllers
{
    public class CarController : BaseController
    {        
        private readonly ICarService carService;

        public CarController(
            UserManager<ApplicationUser> userManager, 
            ICarService carService, 
            IUserService userService)
            : base(userManager, userService)
        {
            this.carService = carService;
        }

        [HttpPost]
        public async Task<IActionResult> Overview(int carId)
        {
            if (await UserHasRights(carId))
            {
                var carOverview = await carService.GetOverviewData(carId);
                return View(carOverview);
            }
            return RedirectToAction("AccessDenied", "Home");
        }

        //[HttpGet]
        public async Task<IActionResult> Edit(int carId)
        {
            var entity = await carService.GetCarInfo(carId);
            return View(entity);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(CarViewModel car, int carId)
        {
            if (!ModelState.IsValid)
            {
                var entity = await carService.GetCarInfo(carId);
                return View(entity);
            }
            if (await UserHasRights(carId))
            {
                await carService.SaveCar(car);
                return RedirectToAction(nameof(All));
            }
            return RedirectToAction("AccessDenied", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int carId)
        {
            if (await UserHasRights(carId))
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
