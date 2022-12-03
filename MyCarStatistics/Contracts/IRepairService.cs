using MyCarStatistics.Models;

namespace MyCarStatistics.Contracts
{
    public interface IRepairService
        //Repair
    {
        Task AddService(RepairViewModel model);
        Task<int> Delete(int serviceId);
        Task<RepairViewModel> GetCar(int carId);
        Task<IEnumerable<RepairViewModel>> GetServices(int carId);
    }
}
