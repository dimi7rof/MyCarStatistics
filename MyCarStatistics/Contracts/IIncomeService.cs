using MyCarStatistics.Models;

namespace MyCarStatistics.Contracts
{
    public interface IIncomeService
    {
        Task AddIncome(IncomeViewModel model);
        Task<int> Delete(int incomeId);
        Task<IncomeViewModel> GetCar(int carId);
        Task<IEnumerable<IncomeViewModel>> GetIncomes(int carId);
    }
}
