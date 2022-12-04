using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyCarStatistics.Contracts;
using MyCarStatistics.Data.Models.Account;

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
            var users = await adminService.GetAllUsers();
            return View(users);
        }

        [HttpPost]
        public async Task<IActionResult> MakeAdmin(string userID)
        {
            var user = await userManager.FindByNameAsync(User.Identity?.Name);
            //var user = await adminService.GetUser(userID);
            await userManager.AddToRoleAsync(user, "Admin");
            return RedirectToAction("Users", "Administrator");
        }

        [HttpPost]
        public async Task<IActionResult> MakeUser(string userID)
        {
            var user = await userManager.FindByNameAsync(User.Identity?.Name);
            //var user = await adminService.GetUser(userID);
            await userManager.RemoveFromRoleAsync(user, "Admin");
            return RedirectToAction("Users", "Administrator");
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var allCars = await adminService.GetAllCars();
            return View(allCars);
        }

    }
}
