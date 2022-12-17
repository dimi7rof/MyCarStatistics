using Ganss.Xss;
using Microsoft.EntityFrameworkCore;
using MyCarStatistics.Contracts;
using MyCarStatistics.Data;
using MyCarStatistics.Models;
using MyCarStatistics.Repositories;
using MyCarStatistics.Services;

namespace MyCarStatistics.Test
{

    public class ExpenseServiceTest
    {
        private IExpenseService expenseService;
        private ICarService carService;
        private ApplicationDbContext context;

        [SetUp]
        public async Task Setup()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("TestDB");
            context = new ApplicationDbContext(optionsBuilder.Options);
          
            var repo = new Repository(context);

            expenseService = new ExpenseService(repo, new HtmlSanitizer());
            carService = new CarService(repo, new HtmlSanitizer());

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var testCar = new CarViewModel() { Id = 99, Brand = "TestBrand", CarModel = "TestModel" };
            await carService.Add(testCar, "test-user-id");

            var expenseTest = new ExpenseViewModel() { Id = 1, Cost = 333, Description = "Breaks", CarId = 99 };
            await expenseService.AddExpense(expenseTest);
        }

        [Test]
        public async Task AddExpenseTest()
        {
            Assert.That(context.Expenses.Any(x => x.CarId == 1), Is.False);

            var expenseTest = new ExpenseViewModel() {Id = 2, Cost = 100, Description = "Paint", CarId = 1 };

            await expenseService.AddExpense(expenseTest);

            Assert.That(context.Expenses.Any(x => x.CarId == 1), Is.True);
        }

        [Test]
        public async Task DeleteExpenseTest()
        {
            Assert.That(context.Expenses.Where(x => x.CarId == 99).Where(x => !x.IsDeleted).Count, Is.EqualTo(1));

            await expenseService.Delete(1);

            Assert.That(context.Expenses.Where(x => x.CarId == 99).Where(x => !x.IsDeleted).Count, Is.EqualTo(0));
        }

        [Test]
        public async Task GetCarTest()
        {
            
            var carTest = await expenseService.GetCar(99);

            Assert.That(carTest.CarModel, Is.EqualTo("TestModel"));
        }

        [Test]
        public async Task GetExpensesTest()
        {

        }
    }
}
