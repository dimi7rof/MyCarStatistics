using MyCarStatistics.Models;

namespace MyCarStatistics.Contracts
{
    public interface IServiceService
    {
        Task AddService(ServiceViewModel model);
        Task<int> Delete(int serviceId);
        Task<ServiceViewModel> GetCar(int carId);
        Task<IEnumerable<ServiceViewModel>> GetServices(int carId);
    }
}
