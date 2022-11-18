using Microsoft.EntityFrameworkCore;
using MyCarStatistics.Contracts;
using MyCarStatistics.Data;
using MyCarStatistics.Data.Models;
using MyCarStatistics.Models;

namespace MyCarStatistics.Services
{
    public class RefuelService : IRefuelService
    {
        private readonly ApplicationDbContext context;

        public RefuelService(ApplicationDbContext _context)
        {
            context = _context;
        }
        
        public Task Delete(string carId)
        {
            throw new NotImplementedException();
        }

        public async Task<RefuelViewModel> GetCar(int carId)
        {
            var entity = await context.Cars
                .FirstOrDefaultAsync(x => x.Id == carId);
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
            var entities = await context.Refuels
                .Where(x => x.CarId == carId && !x.IsDeleted)
                .ToListAsync();

            return entities
                .Select(m => new RefuelViewModel()
                {
                    Id = m.Id,
                    CarModel = m.Car.CarModel,
                    Brand = m.Car.Brand,
                    Liters = m.Liters,
                    Cost = m.Cost ?? 0,
                    DrivenKm = m.DrivenKm ?? 0,
                    GasStation = m.GasStation
                });
        }

        public async Task Refuel(RefuelViewModel model)
        {
            var refuel = new Refuel()
            {
                Liters = model.Liters,
                Cost = model.Cost,
                DrivenKm = model.DrivenKm,
                GasStation = model.GasStation,
                Date = DateTime.Now,
                IsDeleted = false,
                CarId = model.CarId
            };
            await context.Refuels.AddAsync(refuel);
            await context.SaveChangesAsync();
        }
    }
}
