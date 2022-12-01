using MyCarStatistics.Data.Models.Account;
using MyCarStatistics.Models;

namespace MyCarStatistics.Contracts
{
    public interface IAdminService
    {
        Task<IEnumerable<UserViewModel>> GetUsers();

        Task<ApplicationUser> GetUser(string userId);

        Task<IEnumerable<CarViewModel>> GetAllCars();
    }
}
