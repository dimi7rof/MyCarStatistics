using MyCarStatistics.Data.Models.Account;
using MyCarStatistics.Models;

namespace MyCarStatistics.Contracts
{
    public interface IAdminService
    {
        Task<ApplicationUser> GetUser(string userId);

        Task<IEnumerable<CarViewModel>> GetAllCars();
    }
}
