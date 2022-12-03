using MyCarStatistics.Contracts;
using MyCarStatistics.Data.Models;
using MyCarStatistics.Models;
using MyCarStatistics.Repositories;

namespace MyCarStatistics.Services
{
    public class CarInfoService : ICarInfo
    {
        private readonly IRepository repo;

        public CarInfoService(IRepository repo)
            => this.repo = repo;
        
        public async Task<BaseCarInfoVM> GetCarInfo(int carId)
        {
            var entity = await repo.GetByIdAsync<Car>(carId);

            return new BaseCarInfoVM()
            {
                Id = carId,
                Brand = entity.Brand,
                CarModel = entity.CarModel,
                Mileage = entity.Mileage
            };
        }
    }
}
