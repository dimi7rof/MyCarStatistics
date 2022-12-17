using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyCarStatistics.Contracts;
using MyCarStatistics.Data.Models.Account;

namespace MyCarStatistics.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        protected readonly UserManager<ApplicationUser> userManager;
        protected readonly IUserService userService;

        public BaseController(UserManager<ApplicationUser> userManager, IUserService userService)
        {
            this.userManager = userManager;
            this.userService = userService;
        }
       
        protected async Task<bool> UserHasRights(int carId)
        {
            var user = await userManager.FindByNameAsync(User.Identity?.Name);
            return
                await userManager.IsInRoleAsync(user, "Admin") ||
                await userService.CheckUserOwnCar(carId, user.Id);
        }
    }
}
