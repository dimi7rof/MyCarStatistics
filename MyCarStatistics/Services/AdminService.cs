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
            => await repo.AllReadonly<Car>()
                    .Include(u => u.User)
                    .Select(m => new CarViewModel()
                        {
                            Id = m.Id,
                            CarModel = m.CarModel,
                            Brand = m.Brand,
                            Mileage = m.Mileage,
                            User = m.User.UserName,
                            IsDeleted = m.IsDeleted                            
                        })
                    .ToListAsync();


        public async Task<IEnumerable<UserViewModel>> GetAllUsers()
        {
            var result = await repo.AllReadonly<ApplicationUser>().ToListAsync();

            return result
                 .Select(u => new UserViewModel()
                 {
                     UserName = u.UserName,
                     Email = u.Email,
                     Id = u.Id,
                     IsDeleted = u.IsDeleted,
                     IsAdmin = userManager.IsInRoleAsync(u, "Admin").Result
                 });
        }
        public async Task RestoreCar(int carId)
        {
            var car = await repo.GetByIdAsync<Car>(carId);
            car.IsDeleted = false;
            await repo.SaveChangesAsync();
        }
    }
}
