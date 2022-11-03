using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyCarStatistics.Contracts;
using MyCarStatistics.Data.Models;
using MyCarStatistics.Data.Models.Account;
using MyCarStatistics.Models;
using MyCarStatistics.Services;

namespace MyCarStatistics.Controllers
{
    public class RefuelController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ICarService carService;

        public RefuelController(UserManager<ApplicationUser> userManager, ICarService carService)
        {
            this.userManager = userManager;
            this.carService = carService;
        }

        [HttpGet]
        public async Task<IActionResult> Refuel()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var userId = user.Id.ToString();
            var allCars = await carService.GetAll(userId);
            var refuel = new RefuelViewModel()
            {
                Cars = allCars.ToList()
            };
            return View(refuel);
        }
        [HttpPost]
        public async Task<IActionResult> Refuel(RefuelViewModel refuel)
        {
            if (!ModelState.IsValid)
            {
                return View(refuel);
            }
            
            await carService.Refuel(refuel, "1");

            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {

            return View();
        }
    }
}
