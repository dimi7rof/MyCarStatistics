using MyCarStatistics.Models;

namespace MyCarStatistics.Contracts
{
    public interface IUserService
    {
        Task<UserViewModel> GetUser(string userId);
               
        Task<bool> CheckUserOwnCar(int carId, string userId);

        Task SaveUser(UserViewModel user);

        Task Delete(string userId);
    }
}
