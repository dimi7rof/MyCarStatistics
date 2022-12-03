using Ganss.Xss;
using Microsoft.EntityFrameworkCore;
using MyCarStatistics.Contracts;
using MyCarStatistics.Data;
using MyCarStatistics.Data.Models;
using MyCarStatistics.Models;
using MyCarStatistics.Repositories;

namespace MyCarStatistics.Services
{
    public class RefuelService : IRefuelService
    {        
        private readonly IRepository repo;
        private readonly IHtmlSanitizer sanitizer;

        public RefuelService(IRepository repo, IHtmlSanitizer sanitizer)
        {
            this.repo = repo;
            this.sanitizer = sanitizer;
        }

        public async Task<int> Delete(int refId)
        {
            var entity = await repo.GetByIdAsync<Refuel>(refId);
            entity.IsDeleted = true;
            await repo.SaveChangesAsync();
            return entity.CarId;
        }

        public async Task<BaseCarInfoVM> GetCar(int carId)
        {
            var entity = await repo.GetByIdAsync<Car>(carId);
            var car = new RefuelViewModel()
            {
                CarId = carId,
                Brand = entity.Brand,
                CarModel = entity.CarModel
            };
            return car;
        }

        public async Task<IEnumerable<RefuelViewModel>> GetRefuels(int carId)
        {
            var car = await repo.GetByIdAsync<Car>(carId);
            var entities = await repo.AllReadonly<Refuel>()
                .Where(i => i.CarId == carId && !i.IsDeleted)
                .ToListAsync();

            return entities
                .Select(r => new RefuelViewModel()
                {
                    Id = r.Id,
                    CarModel = car.CarModel,
                    Brand = car.Brand,
                    Liters = r.Liters,
                    Cost = r.Cost,
                    Trip = r.Trip ?? 0,
                    GasStation = r.GasStation ?? string.Empty,
                    Date = r.Date
                });
        }

        public async Task AddRefuel(RefuelViewModel model)
        {
            var refuel = new Refuel()
            {
                Liters = model.Liters,
                Cost = model.Cost,
                Trip = model.Trip,
                GasStation = sanitizer.Sanitize(model.GasStation),
                Date = DateTime.Now,
                IsDeleted = false,
                CarId = model.CarId
            };

            //Increase mileage after refueling
            var car = await repo.GetByIdAsync<Car>(model.CarId);
            car.Mileage += model.Trip;
            await repo.AddAsync(refuel);
            await repo.SaveChangesAsync();

        }

        
    }
}
