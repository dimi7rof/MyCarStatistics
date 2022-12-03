using MyCarStatistics.Models;

namespace MyCarStatistics.Contracts
{
    public interface ICarInfo
    {
        Task<BaseCarInfoVM> GetCarInfo(int carId);
    }
}
