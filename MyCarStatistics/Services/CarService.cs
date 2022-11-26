using Microsoft.EntityFrameworkCore;
using MyCarStatistics.Contracts;
using MyCarStatistics.Data.Models;
using MyCarStatistics.Models;
using MyCarStatistics.Repositories;

namespace MyCarStatistics.Services
{
    public class CarService : ICarService
    {
        
        private readonly IRepository repo;

        public CarService(IRepository repo)
        {
            this.repo = repo;
        }


        public async Task Add(CarViewModel model, string userId)
        {
            var car = new Car()
            {
                Brand = model.Brand,
                CarModel = model.CarModel,
                CreatedOn = DateTime.Now,
                IsDeleted = false,
                Mileage = 0,
                UserId = userId
            };

            await repo.AddAsync(car);
            await repo.SaveChangesAsync();
        }

        public async Task Delete(int carId)
        {
            var entity =await repo.GetByIdAsync<Car>(carId);
            entity.IsDeleted = true;
            await repo.SaveChangesAsync();
        }

        public async Task<IEnumerable<CarViewModel>> GetAll(string userId)
        {
            var entities = await repo.AllReadonly<Car>()
                .Where(x => x.UserId == userId && !x.IsDeleted)
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
               

        public async Task<CarViewModel> GetCarInfo(int carId)
        {
            var entity = await repo.AllReadonly<Car>()
                .FirstOrDefaultAsync(x => x.Id == carId);
            var car = new CarViewModel()
            { 
                Id = carId,
                Brand = entity.Brand,
                CarModel = entity.CarModel,
                Mileage = entity.Mileage
            };
            return car;
        }

        public async Task<OverviewModel> GetOverviewData(int carId)
        {
            
            var carInfo = await repo.AllReadonly<Car>()
               .Where(x => !x.IsDeleted)
               .Include(r => r.Refuels)
               .Include(e => e.Expenses)
               .Include(i => i.Incomes)
               .FirstOrDefaultAsync(x => x.Id == carId);

           
            var overview = new OverviewModel()
            {
                Id = carId,
                CarModel = carInfo.CarModel,
                Brand = carInfo.Brand,
                Mileage = carInfo.Mileage,
                MoneyEarned = carInfo.Incomes.Sum(i => i.Earned),
                TotalCostRefuels = carInfo.Refuels.Sum(e => e.Cost),
                TotalCostExpenses = carInfo.Expenses.Sum(e => e.Cost),
                TotalCostServices = carInfo.Refuels.Sum(e => e.Cost),
                TotalLiters = carInfo.Refuels.Sum(e => e.Liters),
                Refuels = carInfo.Refuels.Count()
            };

            return overview;
        }       

        public async Task SaveCar(CarViewModel model)
        {
            var entity = await repo.GetByIdAsync<Car>(model.Id);
            entity.Brand = model.Brand;
            entity.Mileage = model.Mileage;
            entity.CarModel = model.CarModel;

            await repo.SaveChangesAsync();
        }

        public async Task<bool> CheckUser(int carId, string userId)
        {
            var car = await repo.GetByIdAsync<Car>(carId);
            return car.UserId.Equals(userId);
        }
    }
}
