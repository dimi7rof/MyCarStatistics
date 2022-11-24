using Microsoft.EntityFrameworkCore;
using MyCarStatistics.Contracts;
using MyCarStatistics.Data;
using MyCarStatistics.Data.Models;
using MyCarStatistics.Models;
using MyCarStatistics.Repository;

namespace MyCarStatistics.Services
{
    public class RefuelService : IRefuelService
    {        
        private readonly IRepository repo;

        public RefuelService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task<int> Delete(int refId)
        {
            var entity = await repo.GetByIdAsync<Refuel>(refId);
            entity.IsDeleted = true;
            await repo.SaveChangesAsync();
            return entity.CarId;
        }

        public async Task<RefuelViewModel> GetCar(int carId)
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
                    Cost = r.Cost ?? 0,
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
                GasStation = model.GasStation,
                Date = DateTime.Now,
                IsDeleted = false,
                CarId = model.CarId
            };
            await repo.AddAsync(refuel);
            await repo.SaveChangesAsync();

        }

        
    }
}
