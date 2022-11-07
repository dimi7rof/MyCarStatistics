using MyCarStatistics.Models;

namespace MyCarStatistics.Contracts
{
    public interface ICarService
    {
        Task<IEnumerable<CarViewModel>> GetAll(string userID);

        Task Add(CarViewModel carViewModel, string userID);

        Task Delete(string carId);

        Task ImportCars();
    }
}
