using MyCarStatistics.Models;

namespace MyCarStatistics.Contracts
{
    public interface ICarService
    {
        Task<IEnumerable<CarViewModel>> GetAll(string userID);

        Task Add(CarViewModel carViewModel, string userID);

        public Task Refuel(RefuelViewModel model);

        Task Delete(string userId);

       
    }
}
