using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyCarStatistics.Contracts;
using MyCarStatistics.Data.Models.Account;
using MyCarStatistics.Services;

namespace MyCarStatistics.Areas.Admin.Controllers
{
    public class AdminController : BaseController
    {
        private readonly IAdminService adminService;
        private readonly UserManager<ApplicationUser> userManager;

        public AdminController(IAdminService adminService, 
                UserManager<ApplicationUser> userManager)
        {
            this.adminService = adminService;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Users()
        {
            var users = adminService.GetUsers();
            
            return View(users);
        }

        [HttpPost]
        public async Task<IActionResult> MakeAdmin(string userID)
        {
            var user = await adminService.GetUser(userID);
            userManager.AddToRoleAsync(user, "Admin").Wait();
            return RedirectToAction("Admin", "Users");
        }

        [HttpPost]
        public async Task<IActionResult> MakeUser(string userID)
        {
            var user = await adminService.GetUser(userID);
            userManager.AddToRoleAsync(user, "User").Wait();
            return RedirectToAction("Admin", "Users");
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {            
            var allCars = await adminService.GetAll();
            return View(allCars);
        }

    }
}
