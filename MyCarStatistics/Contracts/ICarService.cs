using MyCarStatistics.Data.Models;
using MyCarStatistics.Models;

namespace MyCarStatistics.Contracts
{
    public interface ICarService
    {
        Task<IEnumerable<CarViewModel>> GetAll(string userID);

        Task Add(CarViewModel model, string userID);

        Task Delete(int carID);

        Task ImportCars();

        Task<OverviewModel> GetOverviewData(int carID, string userID);

        Task<CarViewModel> GetCarInfo(int carID);

        Task SaveCar(CarViewModel model);
    }
}
