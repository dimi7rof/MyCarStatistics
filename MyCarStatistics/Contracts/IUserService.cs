using MyCarStatistics.Models;

namespace MyCarStatistics.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<UserViewModel>> GetUsers();
               
        Task<bool> CheckUser(int carId, string userId);
    }
}
