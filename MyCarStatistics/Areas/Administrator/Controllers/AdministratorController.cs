using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyCarStatistics.Contracts;
using MyCarStatistics.Data.Models.Account;
using MyCarStatistics.Models;
using MyCarStatistics.Services;

namespace MyCarStatistics.Areas.Administrator.Controllers
{
    public class AdministratorController : BaseController
    {
        private readonly IAdminService adminService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserService userService;

        public AdministratorController(IAdminService adminService,
                UserManager<ApplicationUser> userManager,
                IUserService userService)
        {
            this.adminService = adminService;
            this.userManager = userManager;
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
            => View();

        [HttpGet]
        public async Task<IActionResult> Users()
        {
            IEnumerable<UserViewModel> users = await adminService.GetAllUsers();
            return View(users);
        }

        [HttpPost]
        public async Task<IActionResult> MakeAdmin(string userID)
        {
            var user = await userManager.FindByIdAsync(userID);
            await userManager.AddToRoleAsync(user, "Admin");
            return RedirectToAction("Users", "Administrator");
        }

        [HttpPost]
        public async Task<IActionResult> MakeUser(string userID)
        {
            var user = await userManager.FindByIdAsync(userID);
            await userManager.RemoveFromRoleAsync(user, "Admin");
            return RedirectToAction("Users", "Administrator");
        }

        [HttpGet]
        public async Task<IActionResult> Cars()
        {
            var allCars = await adminService.GetAllCars();
            return View(allCars);
        }

        public async Task<IActionResult> DeleteUser(string userId)
        {
            await userService.Delete(userId);
            return RedirectToAction("Users", "Administrator");
        }

        public async Task<IActionResult> Restore(int carId)
        {
            await adminService.RestoreCar(carId);
            return RedirectToAction("Cars", "Administrator");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCar(int carId)
        {
            await adminService.Delete(carId);
            return RedirectToAction("Cars", "Administrator");
        }
    }
}
