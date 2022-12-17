using Ganss.Xss;
using Microsoft.AspNetCore.Identity;
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
        private readonly IHtmlSanitizer sanitizer;

        public UserService(UserManager<ApplicationUser> userManager, IRepository repo, IHtmlSanitizer sanitizer)
        {
            this.userManager = userManager;
            this.repo = repo;
            this.sanitizer = sanitizer;
        }

        public async Task<bool> CheckUserOwnCar(int carId, string userId)
        {
            if (carId == 0)
            {
                return false;
            }
            var car = await repo.GetByIdAsync<Car>(carId);
            return car.UserId.Equals(userId);

        }

        public async Task Delete(string userId)
        {
            var user = await repo.GetByIdAsync<ApplicationUser>(userId);
            user.Email = null;
            user.FirstName = null;
            user.LastName = null;
            user.UserName = null;
            user.IsDeleted = true;
            await repo.SaveChangesAsync();
        }

        public async Task<UserViewModel> GetUser(string userId)
        {
            var user = await repo.GetByIdAsync<ApplicationUser>(userId);
            return new UserViewModel()
            {
                UserName = user.UserName,
                Email = user.Email,
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                IsDeleted = user.IsDeleted,
                IsAdmin = userManager.IsInRoleAsync(user, "Admin").Result
            };
        }

        public async Task SaveUser(UserViewModel user)
        {
            var entity = await repo.GetByIdAsync<ApplicationUser>(user.Id);
            entity.UserName = sanitizer.Sanitize(user.UserName);
            entity.FirstName = sanitizer.Sanitize(user.FirstName ?? string.Empty);
            entity.LastName = sanitizer.Sanitize(user.LastName ?? string.Empty);

            await repo.SaveChangesAsync();
        }
    }
}
