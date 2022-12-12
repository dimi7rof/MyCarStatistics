using Ganss.Xss;
using Microsoft.EntityFrameworkCore;
using Moq;
using MyCarStatistics.Contracts;
using MyCarStatistics.Data;
using MyCarStatistics.Data.Models;
using MyCarStatistics.Data.Models.Account;
using MyCarStatistics.Models;
using MyCarStatistics.Repositories;
using MyCarStatistics.Services;
using NUnit.Framework.Internal;

namespace MyCarStatistics.Test
{
    public class CarServiseTest
    {
        private ICarService carService;
        private ApplicationDbContext context;

        [SetUp]
        public async Task Setup()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("TestDB");

            context = new ApplicationDbContext(optionsBuilder.Options);

            var repo = new Repository(context);

            carService = new CarService(repo, new HtmlSanitizer());

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();


            var testCar = new CarViewModel() { Id = 1, Brand = "TestBrand", CarModel = "TestModel" };
            await carService.Add(testCar, "test-user-id");
            var testCar2 = new CarViewModel() { Id = 2, Brand = "TestBrand2", CarModel = "TestModel2" };
            await carService.Add(testCar2, "test-user-id");
        }


        [Test]
        public async Task AddingCarToDBTest()
        {
            Assert.That(context.Cars.Count(), Is.EqualTo(2));

            var testCar = new CarViewModel() { Id = 3, Brand = "TestBrand3", CarModel = "TestModel3" };
            await carService.Add(testCar, "test-user-id");

            Assert.That(context.Cars.Count(), Is.EqualTo(3));
        }

        [Test]
        public async Task DeleteCarTest()
        {
            await carService.Delete(1);

            Assert.That(context.Cars.Where(x => x.Id == 1 && x.IsDeleted == true).Count, Is.EqualTo(1));
        }

        [Test]
        public async Task GetAllCarsTest()
        {
            var testCar4 = new CarViewModel() { Id = 4, Brand = "TestBrand4", CarModel = "TestModel4" };
            await carService.Add(testCar4, "test-user-id");

            var allCars = await carService.GetAll("test-user-id");

            Assert.That(allCars.Count(), Is.EqualTo(3));
        }

        [Test]
        public async Task GetCatInfoTest()
        {
            var testCar = new CarViewModel() { Id = 5, Brand = "TestBrand5", CarModel = "TestModel5" };
            await carService.Add(testCar, "test-user-id");

            var car = await carService.GetCarInfo(1);

            Assert.That(car.Id, Is.EqualTo(1));
            Assert.That(car.Brand, Is.EqualTo("TestBrand"));
            Assert.That(car.CarModel, Is.EqualTo("TestModel"));
        }

        [Test]
        public async Task SaveCarTest()
        {
            var testCar = new CarViewModel() { Id = 1, Brand = "EditedBrand", CarModel = "EditedModel" };

            await carService.SaveCar(testCar);

            var editCar = context.Cars.FirstOrDefault(x => x.Id == 1);

            Assert.That(editCar.Brand, Is.EqualTo("EditedBrand"));
        }

        [Test]
        public async Task GetOverViewTest()
        {
            var overView = await carService.GetOverviewData(1);

            Assert.That(overView.TotalCostServices, Is.EqualTo(0));
            Assert.That(overView.Mileage, Is.EqualTo(0));


        }
    }
}
