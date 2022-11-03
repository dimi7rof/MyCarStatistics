using Microsoft.EntityFrameworkCore;
using MyCarStatistics.Contracts;
using MyCarStatistics.Data;
using MyCarStatistics.Data.Models;
using MyCarStatistics.Models;
using Newtonsoft.Json;
using System.Text;

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
        public async Task Refuel(RefuelViewModel model, string carId)
        {
            var refuel = new Refuel()
            {
                Liters = model.Liters,
                Cost = model.Cost,
                DrivenKm = model.DrivenKm,
                GasStation = model.GasStation,
                Date = DateTime.Now,
                IsDeleted = false
            };
            await context.Refuels.AddAsync(refuel);
            await context.SaveChangesAsync();
        }


        public Task Delete(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CarViewModel>> GetAll(string userID)
        {
            var entities = await context.Cars
                .Where(x => x.UserId == userID || !x.IsDeleted)
                .ToListAsync();

            return entities
                .Select(m => new CarViewModel()
                {
                    CarModel = m.CarModel,
                    Brand = m.Brand,
                    Mileage = m.Mileage
                });
        }

       








        public async Task ImportCars()
        {
        //    string inputJson = File.ReadAllText("../../../Data/Seed/CarBrandsAndModels.json");
        //    StringBuilder sb = new StringBuilder();

        //    AllCars[] allCars = JsonConvert.DeserializeObject<AllCars[]>(inputJson);

        //    context.AllCars.AddRange(allCars);
        //    context.SaveChanges();

        }

    }
}
