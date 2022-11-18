using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyCarStatistics.Contracts;
using MyCarStatistics.Data.Models.Account;
using MyCarStatistics.Models;

namespace MyCarStatistics.Controllers
{
    public class RefuelController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IRefuelService refuelService;
        private readonly ICarService carService;

        public RefuelController(UserManager<ApplicationUser> userManager, IRefuelService refuelService, ICarService carService)
        {
            this.userManager = userManager;
            this.refuelService = refuelService;
            this.carService = carService;
        }

        [HttpGet]
        public async Task<IActionResult> Refuel(int CarId)
        {
            //var user = await userManager.FindByNameAsync(User.Identity.Name);
            //var userId = user.Id.ToString();
            //var allCars = await carService.GetAll(userId);
            //var refuel = new RefuelViewModel()
            //{
            //    Cars = allCars.ToList()
            //};
            var model = await refuelService.GetCar(CarId);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Refuel(RefuelViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            await refuelService.Refuel(model);

            return RedirectToAction("All");
        }
        public async Task<IActionResult> All(int carId)
        {
            var allRefuels = await refuelService.GetRefuels(carId);
            ViewBag.AllLiters = allRefuels.Sum(r => r.Liters);
            ViewBag.AllCost = allRefuels.Sum(r => r.Cost);
            ViewBag.AllKm = allRefuels.Sum(r => r.DrivenKm);
            return View(allRefuels);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
