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

        public AdminService(IRepository repo)
            => this.repo = repo;
        
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

           
    }
}
