using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyCarStatistics.Contracts;
using MyCarStatistics.Data.Models.Account;
using MyCarStatistics.Models;

namespace MyCarStatistics.Controllers
{
    public class ExpenseController : BaseController
    {
        private readonly IExpenseService expenseService;
               
        public ExpenseController(
            IExpenseService expenseService,
            UserManager<ApplicationUser> userManager,
            IUserService userService)
            : base(userManager, userService)
        {
            this.expenseService = expenseService;
        }

        [HttpGet]
        public async Task<IActionResult> Add(int carId)
        {
            if (await UserHasRights(carId))
            {
                var model = await expenseService.GetCar(carId);
                return View(model);
            }
            return RedirectToAction("AccessDenied", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Add(ExpenseViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await expenseService.AddExpense(model);
            return RedirectToAction(nameof(All), model.CarId);
        }

        [HttpGet]
        public async Task<IActionResult> All(int carId)
        {
            if (await UserHasRights(carId))
            {
                var all = await expenseService.GetExpenses(carId);
                ViewBag.Id = carId;
                return View(all);
            }
            return RedirectToAction("AccessDenied", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int expenceId)
        {
            var carId = await expenseService.Delete(expenceId);
            return RedirectToAction(nameof(All), carId);
        }
    }
}
