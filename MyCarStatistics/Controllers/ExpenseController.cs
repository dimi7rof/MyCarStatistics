using Microsoft.AspNetCore.Mvc;
using MyCarStatistics.Contracts;
using MyCarStatistics.Models;

namespace MyCarStatistics.Controllers
{
    public class ExpenseController : BaseController
    {
        private readonly IExpenseService expenseService;

        public ExpenseController(IExpenseService _expenseService)
        {
            this.expenseService = _expenseService;
        }

        [HttpGet]
        public async Task<IActionResult> Add(int carId)
        {
            var model = await expenseService.GetCar(carId);
            return View(model);
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
            var all = await expenseService.GetExpenses(carId);
            ViewBag.Id = carId;
            return View(all);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int expenceId)
        {
            var carId = await expenseService.Delete(expenceId);
            return RedirectToAction(nameof(All), carId);
        }
    }
}
