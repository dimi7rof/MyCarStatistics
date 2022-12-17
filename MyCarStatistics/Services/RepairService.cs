using Ganss.Xss;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using MyCarStatistics.Contracts;
using MyCarStatistics.Data.Models;
using MyCarStatistics.Models;
using MyCarStatistics.Repositories;

namespace MyCarStatistics.Services
{
    public class RepairService : IRepairService
    {
        private readonly IRepository repo;
        private readonly IHtmlSanitizer sanitizer;

        public RepairService(IRepository repo, IHtmlSanitizer sanitizer)
        {
            this.repo = repo;
            this.sanitizer = sanitizer;
        }

        public async Task AddService(RepairViewModel model)
        {
            var repair = new Service()
            {
                Date = DateTime.Now,
                IsDeleted = false,
                CarId = model.CarId,
                Description = sanitizer.Sanitize(model.Description ?? string.Empty),
                CurrentKm = model.CurrentMillage,
                Cost = model.Cost
            };
            await repo.AddAsync(repair);
            await repo.SaveChangesAsync();
        }

        public async Task<int> Delete(int serviceId)
        {
            var entity = await repo.GetByIdAsync<Service>(serviceId);
            entity.IsDeleted = true;
            await repo.SaveChangesAsync();
            return entity.CarId;
        }

        public async Task<RepairViewModel> GetCar(int carId)
        {
            var entity = await repo.GetByIdAsync<Car>(carId);
            var car = new RepairViewModel()
            {
                CarId = carId,
                Brand = entity.Brand,
                CarModel = entity.CarModel
            };
            return car;
        }

        public async Task<IEnumerable<RepairViewModel>> GerRepairs(int carId)
        {
            var car = await repo.GetByIdAsync<Car>(carId);
            var repairs = await repo.AllReadonly<Service>()
                .Where(i => i.CarId == carId && !i.IsDeleted)
                .ToListAsync();

            return repairs
                .Select(r => new RepairViewModel()
                {
                    Id = r.Id,
                    CarModel = car.CarModel,
                    Brand = car.Brand,
                    Cost = r.Cost,
                    Date = r.Date,
                    Description = r.Description
                });
        }
    }
}
