﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyCarStatistics.Contracts;
using MyCarStatistics.Data.Models.Account;
using MyCarStatistics.Models;

namespace MyCarStatistics.Controllers
{
    public class RefuelController : BaseController
    {        
        private readonly IRefuelService refuelService;        

        public RefuelController(IRefuelService refuelService)
        {
            this.refuelService = refuelService;
        }

        [HttpGet]
        public async Task<IActionResult> Refuel(int carId)
        {
            var model = await refuelService.GetCar(carId);
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Refuel(RefuelViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            await refuelService.AddRefuel(model);
            return RedirectToAction(nameof(All), model.CarId);
        }


        [HttpGet]
        public async Task<IActionResult> All(int carId)
        {
            var allRefuels = await refuelService.GetRefuels(carId);
            ViewBag.Id = carId;
            return View(allRefuels);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int refId)
        {
            var carId = await refuelService.Delete(refId);
            return RedirectToAction(nameof(All), carId);
        }

    }
}
