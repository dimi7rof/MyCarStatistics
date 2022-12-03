using MyCarStatistics.Models;

namespace MyCarStatistics.Contracts
{
    public interface IRefuelService
    {
        Task AddRefuel(RefuelViewModel model);
        Task<int> Delete(int refId);
        Task<BaseCarInfoVM> GetCar(int carId);
        Task<IEnumerable<RefuelViewModel>> GetRefuels(int carId);
    }
}
