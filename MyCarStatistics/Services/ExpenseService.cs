using Ganss.Xss;
using Microsoft.EntityFrameworkCore;
using MyCarStatistics.Contracts;
using MyCarStatistics.Data.Models;
using MyCarStatistics.Models;
using MyCarStatistics.Repositories;

namespace MyCarStatistics.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IRepository repo;
        private readonly IHtmlSanitizer sanitizer;

        public ExpenseService(IRepository repo, IHtmlSanitizer sanitizer)
        {
            this.repo = repo;
            this.sanitizer = sanitizer;
        }

        public async Task AddExpense(ExpenseViewModel model)
        {
            var expense = new Expense()
            {
                Cost = model.Cost,
                Trip = model.Trip,
                Description = sanitizer.Sanitize(model.Description),
                Date = DateTime.Now,
                IsDeleted = false,
                CarId = model.CarId
            };
            
            await repo.AddAsync(expense);
            await repo.SaveChangesAsync();
        }

        public async Task<int> Delete(int expenseId)
        {
            var entity = await repo.GetByIdAsync<Expense>(expenseId);
            entity.IsDeleted = true;
            await repo.SaveChangesAsync();
            return entity.CarId;
        }

        public async Task<ExpenseViewModel> GetCar(int carId)
        {
            var entity = await repo.GetByIdAsync<Car>(carId);
            var car = new ExpenseViewModel()
            {
                CarId = carId,
                Brand = entity.Brand,
                CarModel = entity.CarModel
            };
            return car;
        }

        public async Task<IEnumerable<ExpenseViewModel>> GetExpenses(int carId)
        {
            var car = await repo.GetByIdAsync<Car>(carId);
            var entities = await repo.AllReadonly<Expense>()
                .Where(i => i.CarId == carId && !i.IsDeleted)
                .ToListAsync();

            return entities
                .Select(r => new ExpenseViewModel()
                {
                    Id = r.Id,
                    CarModel = car.CarModel,
                    Brand = car.Brand,
                    Cost = r.Cost,
                    Date = r.Date,
                    Description= r.Description,
                    CarId= carId
                });
        }
    }
}
