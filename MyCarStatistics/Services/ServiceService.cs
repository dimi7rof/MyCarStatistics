using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using MyCarStatistics.Contracts;
using MyCarStatistics.Data.Models;
using MyCarStatistics.Models;
using MyCarStatistics.Repositories;

namespace MyCarStatistics.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IRepository repo;

        public ServiceService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task AddService(ServiceViewModel model)
        {
            var income = new Service()
            {
                Date = DateTime.Now,
                IsDeleted = false,
                CarId = model.CarId,
                Description = model.Description,
                CurrentKm = model.CurrentMillage,
                Cost = model.Cost
            };
            await repo.AddAsync(income);
            await repo.SaveChangesAsync();
        }

        public async Task<int> Delete(int serviceId)
        {
            var entity = await repo.GetByIdAsync<Service>(serviceId);
            entity.IsDeleted = true;
            await repo.SaveChangesAsync();
            return entity.CarId;
        }

        public async Task<ServiceViewModel> GetCar(int carId)
        {
            var entity = await repo.GetByIdAsync<Car>(carId);
            var car = new ServiceViewModel()
            {
                CarId = carId,
                Brand = entity.Brand,
                CarModel = entity.CarModel
            };
            return car;
        }

        public async Task<IEnumerable<ServiceViewModel>> GetServices(int carId)
        {
            var car = await repo.GetByIdAsync<Car>(carId);
            var entities = await repo.AllReadonly<Service>()
                .Where(i => i.CarId == carId && !i.IsDeleted)
                .ToListAsync();

            return entities
                .Select(r => new ServiceViewModel()
                {
                    Id = r.Id,
                    CarModel = car.CarModel,
                    Brand = car.Brand,
                    Cost = r.Cost ?? 0,
                    Date = r.Date,
                    Description = r.Description
                });
        }
    }
}
