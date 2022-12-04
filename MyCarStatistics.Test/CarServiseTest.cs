using MyCarStatistics.Contracts;
using MyCarStatistics.Data.Models.Account;
using MyCarStatistics.Models;
using NUnit.Framework.Internal;

namespace MyCarStatistics.Test
{
    public class CarServiseTest
    {
        private readonly ICarService carService;

        public CarServiseTest(ICarService carService)
        {
            this.carService = carService;
        }

        [SetUp]
        public void Setup()
        {
           
        }

        [Test]
        public void Test1()
        {
            carService.Add(new CarViewModel()
            {
                Brand = "TestBrand",
                CarModel = "TestModel",
                User = "test-user-id",
            }, "test-user-id");
            Assert.Pass();
        }
    }
}
