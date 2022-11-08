using Microsoft.EntityFrameworkCore;
using MyCarStatistics.Contracts;
using MyCarStatistics.Data;
using MyCarStatistics.Data.Models;
using MyCarStatistics.Models;

namespace MyCarStatistics.Services
{
    public class CarService : ICarService
    {
        private readonly ApplicationDbContext context;

        public CarService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task Add(CarViewModel model, string userID)
        {
            var car = new Car()
            {
                Brand = model.Brand,
                CarModel = model.CarModel,
                CreatedOn = DateTime.Now,
                IsDeleted = false,
                Mileage = 0,
                UserId = userID
            };

            await context.Cars.AddAsync(car);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int carId)
        {
            var entity =await context.Cars.FirstOrDefaultAsync(x => x.Id == carId);
            // TODO
            //entity.IsDeleted = true;
            //context.Update(entity);
            context.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CarViewModel>> GetAll(string userID)
        {
            var entities = await context.Cars
                .Where(x => x.UserId == userID || !x.IsDeleted)
                .ToListAsync();

            return entities
                .Select(m => new CarViewModel()
                {
                    Id = m.Id,
                    CarModel = m.CarModel,
                    Brand = m.Brand,
                    Mileage = m.Mileage
                });
        }

        public async Task<OverviewModel> GetOverviewData(int carId, string userID)
        {
            var carInfo = await context.Cars
                .AsNoTracking()
                .Where(x => x.UserId == userID || !x.IsDeleted)
                .FirstOrDefaultAsync(x => x.Id == carId);

            decimal income = context.Incomes.AsNoTracking()
                .Where(x => x.CarId == carId)
                .Sum(i => i.Earned);

            decimal expenses = context.Expenses.AsNoTracking()
                .Where(x => x.CarId == carId)
                .Sum(e => e.Cost) ?? 0;

            decimal refuels = context.Refuels.AsNoTracking()
                .Where(x => x.CarId == carId)
                .Sum(e => e.Cost) ?? 0;

            int refuelCount = context.Refuels.AsNoTracking()
                .Where(x => x.CarId == carId)
                .Count();

            decimal liters = context.Refuels.AsNoTracking()
               .Where(x => x.CarId == carId)
               .Sum(e => e.Liters);

            decimal services = context.Services.AsNoTracking()
                .Where(x => x.CarId == carId)
                .Sum(e => e.Cost) ?? 0;

            var overview = new OverviewModel()
            {
                CarModel = carInfo.CarModel,
                Brand = carInfo.Brand,
                Mileage = carInfo.Mileage,
                MoneyEarned = income,
                TotalCostRefuels = refuels,
                TotalCostExpenses = expenses,
                TotalCostServices = services,
                TotalLiters = liters,
                Refuels = refuelCount
            };

            return overview;
        }

        public async Task ImportCars()
        {

        }


    }
}
