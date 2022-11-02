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

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var userId = user.Id.ToString();
            var allCars = await carService.GetAll(userId);
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
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var userId = user.Id.ToString();
            carService.Add(car, userId);

            return RedirectToAction("Index", "Home");
        }
        


        [HttpPost]
        public IActionResult Index()
        {


            return Ok();
        }
    }
}
