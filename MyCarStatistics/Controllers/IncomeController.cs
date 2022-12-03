using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyCarStatistics.Contracts;
using MyCarStatistics.Data.Models.Account;
using MyCarStatistics.Models;

namespace MyCarStatistics.Controllers
{
    public class IncomeController : BaseController
    {
        private readonly IIncomeService incomeServise;

        public IncomeController(
            UserManager<ApplicationUser> userManager,
            IIncomeService incomeServise,
            IUserService userService)
            : base(userManager, userService)
        {
            this.incomeServise = incomeServise;
        }

        [HttpGet]
        public async Task<IActionResult> Add(int carId)
        {
            if (await UserHasRights(carId))
            {
                var model = await incomeServise.GetCar(carId);
                return View(model);
            }
            return RedirectToAction("AccessDenied", "Home");           
        }

        [HttpPost]
        public async Task<IActionResult> Add(IncomeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await incomeServise.AddIncome(model);
            return RedirectToAction(nameof(All), model.CarId);
        }

        [HttpGet]
        public async Task<IActionResult> All(int carId)
        {
            if (await UserHasRights(carId))
            {
                var all = await incomeServise.GetIncomes(carId);
                ViewBag.Id = carId;
                return View(all);
            }
            return RedirectToAction("AccessDenied", "Home");            
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int incomeId)
        {
            var carId = await incomeServise.Delete(incomeId);
            return RedirectToAction(nameof(All), carId);
        }
    }
}
