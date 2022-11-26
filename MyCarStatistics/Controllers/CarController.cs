using Microsoft.AspNetCore.Authorization;
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


        [HttpPost]
        public async Task<IActionResult> Overview(int carId)
        {
            var user = await userManager.FindByNameAsync(User?.Identity?.Name);
            if ((await carService.CheckUser(carId, user.Id.ToString())) == false)
            {
                return RedirectToAction("AccessDenied", "Car");
            }
            var carOverview = await carService.GetOverviewData(carId);
            return View(carOverview);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CarViewModel car, int carId)
        {
            var user = await userManager.FindByNameAsync(User?.Identity?.Name);
            if ((await carService.CheckUser(carId, user.Id.ToString())) == false)
            {
                return RedirectToAction("AccessDenied", "Car");
            }
            if (!ModelState.IsValid)
            {
                var entity = await carService.GetCarInfo(carId);
                return View(entity);
            }

            await carService.SaveCar(car);
            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int carId)
        {
            var user = await userManager.FindByNameAsync(User?.Identity?.Name);
            if ((await carService.CheckUser(carId, user.Id.ToString())) == false)
            {
                return RedirectToAction("AccessDenied", "Car");
            }
            await carService.Delete(carId);
            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var user = await userManager.FindByNameAsync(User?.Identity?.Name);
            var allCars = await carService.GetAll(user.Id.ToString());
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
            var user = await userManager.FindByNameAsync(User?.Identity?.Name);
            await carService.Add(car, user.Id.ToString());

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Index()
            => View();

        [HttpGet]
        public IActionResult AccessDenied()
                => View();

        
    }
}
