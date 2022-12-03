using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyCarStatistics.Contracts;
using MyCarStatistics.Data.Models;
using MyCarStatistics.Data.Models.Account;
using MyCarStatistics.Models;
using MyCarStatistics.Repositories;

namespace MyCarStatistics.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IRepository repo;

        public UserService(UserManager<ApplicationUser> userManager, IRepository repo)
        {
            this.userManager = userManager;
            this.repo = repo;
        }

        public async Task<IEnumerable<UserViewModel>> GetUsers()
        {
            List<UserViewModel> users = await repo.AllReadonly<ApplicationUser>()
           .Select(u => new UserViewModel()
           {
               UserName = u.UserName,
               Email = u.Email,
               Id = u.Id,
               IsAdmin = userManager.IsInRoleAsync(u, "Admin").Result
           }).ToListAsync();

            return users;
        }
        
        public async Task<bool> CheckUser(int carId, string userId)
        {
            var car = await repo.GetByIdAsync<Car>(carId);
            return car.UserId.Equals(userId);
        }
    }
}
