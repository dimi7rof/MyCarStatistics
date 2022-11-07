﻿using Microsoft.AspNetCore.Identity;
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
            
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Index()
            => Ok();
        

        [HttpPost]
        public async Task<IActionResult> Import()
        {
            await carService.ImportCars();
            return RedirectToAction("Index", "Home");
        }
    }
}
