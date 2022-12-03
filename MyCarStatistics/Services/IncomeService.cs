using Ganss.Xss;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using MyCarStatistics.Contracts;
using MyCarStatistics.Data.Models;
using MyCarStatistics.Models;
using MyCarStatistics.Repositories;

namespace MyCarStatistics.Services
{
    public class IncomeService : IIncomeService
    {
        private readonly IRepository repo;
        private readonly IHtmlSanitizer sanitizer;

        public IncomeService(IRepository repo, IHtmlSanitizer sanitizer)
        {
            this.repo = repo;
            this.sanitizer = sanitizer;
        }

        public async Task AddIncome(IncomeViewModel model)
        {
            var income = new Income()
            {               
                Date = DateTime.Now,
                IsDeleted = false,
                CarId = model.CarId,
                Description = sanitizer.Sanitize(model.Description),
                Earned = model.MoneyEarned
            };
            await repo.AddAsync(income);
            await repo.SaveChangesAsync();
        }

        public async Task<int> Delete(int incomeId)
        {
            var entity = await repo.GetByIdAsync<Income>(incomeId);
            entity.IsDeleted = true;
            await repo.SaveChangesAsync();
            return entity.CarId;
        }

        public async Task<IncomeViewModel> GetCar(int carId)
        {
            var entity = await repo.GetByIdAsync<Car>(carId);
            var car = new IncomeViewModel()
            {
                CarId = carId,
                Brand = entity.Brand,
                CarModel = entity.CarModel
            };
            return car;
        }

        public async Task<IEnumerable<IncomeViewModel>> GetIncomes(int carId)
        {
            var car = await repo.GetByIdAsync<Car>(carId);
            var entities = await repo.AllReadonly<Income>()
                .Where(i => i.CarId == carId && !i.IsDeleted)
                .ToListAsync();

            return entities
                .Select(r => new IncomeViewModel()
                {
                    Id = r.Id,
                    CarModel = car.CarModel,
                    Brand = car.Brand,
                    Date = r.Date,
                    Description = r.Description,
                    MoneyEarned = r.Earned
                });
        }
    }
}
