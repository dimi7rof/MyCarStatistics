using MyCarStatistics.Models;

namespace MyCarStatistics.Contracts
{
    public interface IRefuelService
    {
        Task Refuel(RefuelViewModel model, string carId);
        Task Delete(string carId);
    }
}
