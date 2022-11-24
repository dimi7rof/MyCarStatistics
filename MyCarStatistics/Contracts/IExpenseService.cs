using MyCarStatistics.Data.Models;
using MyCarStatistics.Models;

namespace MyCarStatistics.Contracts
{
    public interface IExpenseService
    {
        Task AddExpense(ExpenseViewModel model);
        Task<int> Delete(int expenseId);
        Task<ExpenseViewModel> GetCar(int carId);
        Task<IEnumerable<ExpenseViewModel>> GetExpenses(int carId);
    }
}
