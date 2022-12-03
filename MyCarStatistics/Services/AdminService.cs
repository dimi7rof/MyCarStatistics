using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyCarStatistics.Contracts;
using MyCarStatistics.Data.Models;
using MyCarStatistics.Data.Models.Account;
using MyCarStatistics.Models;
using MyCarStatistics.Repositories;

namespace MyCarStatistics.Services
{
    public class AdminService : IAdminService
    {
        private readonly IRepository repo;
        private readonly UserManager<ApplicationUser> userManager;       
        public AdminService(IRepository repo, UserManager<ApplicationUser> userManager)
        {
            this.repo = repo;
            this.userManager = userManager;
        }

        public async Task<IEnumerable<CarViewModel>> GetAllCars()
        {
            var entities = await repo.AllReadonly<Car>()
                .Where(c => c.IsDeleted== false)
                .Include(u => u.User)
                .ToListAsync();

            return entities
                .Select(m => new CarViewModel()
                {
                    Id = m.Id,
                    CarModel = m.CarModel,
                    Brand = m.Brand,
                    Mileage = m.Mileage,
                    User = m.User.UserName
                });
        }

        public Task<ApplicationUser> GetUser(string userId)
            => repo.GetByIdAsync<ApplicationUser>(userId);        

        public async Task<IEnumerable<UserViewModel>> GetUsers()
        {
            List<UserViewModel> users = await repo.AllReadonly<ApplicationUser>()
            .Select( u => new UserViewModel()
            {
                UserName = u.UserName,
                Email = u.Email,
                Id = u.Id,
                IsAdmin = userManager.IsInRoleAsync(u, "Admin").Result
            }).ToListAsync();

            return users;
        }       
    }
}
