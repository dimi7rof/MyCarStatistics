using Ganss.Xss;
using Microsoft.EntityFrameworkCore;
using MyCarStatistics.Contracts;
using MyCarStatistics.Data;
using MyCarStatistics.Models;
using MyCarStatistics.Repositories;
using MyCarStatistics.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarStatistics.Test
{
    public class IncomeServiceTest
    {
        private IIncomeService incomeService;
        private ICarService carService;
        private ApplicationDbContext context;

        [SetUp]
        public async Task Setup()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("TestDB");
            context = new ApplicationDbContext(optionsBuilder.Options);

            var repo = new Repository(context);

            incomeService = new IncomeService(repo, new HtmlSanitizer());
            carService = new CarService(repo, new HtmlSanitizer());

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var testCar = new CarViewModel() { Id = 1, Brand = "TestBrand", CarModel = "TestModel" };
            await carService.Add(testCar, "test-user-id");

            var incomeTest = new IncomeViewModel() { Id = 1, MoneyEarned = 333, Description = "Uber", CarId = 1};
            await incomeService.AddIncome(incomeTest);
        }

        [Test]
        public async Task AddIncomeTest()
        {
            Assert.That(context.Incomes.Any(x => x.CarId == 99), Is.False);

            var incomeTest = new IncomeViewModel() { Id = 1, MoneyEarned = 333, Description = "Uber", CarId = 99 };

            await incomeService.AddIncome(incomeTest);

            Assert.That(context.Incomes.Any(x => x.CarId == 99), Is.True);
        }

        [Test]
        public async Task DeleteIncomeTest()
        {
            Assert.That(context.Incomes.Where(x => x.CarId == 1).Where(x => !x.IsDeleted).Count, Is.EqualTo(1));

            await incomeService.Delete(1);

            Assert.That(context.Incomes.Where(x => x.CarId == 1).Where(x => !x.IsDeleted).Count, Is.EqualTo(0));
        }


    }
}
