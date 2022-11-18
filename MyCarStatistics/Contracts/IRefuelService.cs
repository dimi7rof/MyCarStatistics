using MyCarStatistics.Models;

namespace MyCarStatistics.Contracts
{
    public interface IRefuelService
    {
        Task Refuel(RefuelViewModel model);
        Task Delete(string carId);
        Task<RefuelViewModel> GetCar(int carId);
        Task<IEnumerable<RefuelViewModel>> GetRefuels(int carId);
    }
}
