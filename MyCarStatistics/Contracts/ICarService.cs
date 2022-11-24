using MyCarStatistics.Data.Models;
using MyCarStatistics.Models;

namespace MyCarStatistics.Contracts
{
    public interface ICarService
    {
        Task<IEnumerable<CarViewModel>> GetAll(string userId);

        Task Add(CarViewModel model, string userID);

        Task Delete(int carId);
       
        Task<OverviewModel> GetOverviewData(int carId);

        Task<CarViewModel> GetCarInfo(int carId);

        Task SaveCar(CarViewModel model);

    }
}
