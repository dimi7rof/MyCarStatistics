﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyCarStatistics.Contracts;
using MyCarStatistics.Data.Models;
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
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            OverviewModel carOverview = await carService.GetOverviewData(carId, user.Id.ToString());
            return View(carOverview);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CarViewModel car, int carID)
        {
            if (car.Brand == null)
            {
                var entity = await carService.GetCarInfo(carID);
                return View(entity);
            }

            await carService.SaveCar(car);
            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int carID)
        {
            await carService.Delete(carID);
            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var allCars = await carService.GetAll(user.Id.ToString());
            return View(allCars);
        }

        [HttpGet]
        public async Task<IActionResult> AddCar()
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
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            await carService.Add(car, user.Id.ToString());

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public IActionResult Index()
            => Ok();


        [HttpGet]
        public async Task<IActionResult> Import()
        {
            await carService.ImportCars();
            return RedirectToAction(nameof(All));
        }
    }
}
