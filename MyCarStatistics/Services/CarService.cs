using Microsoft.EntityFrameworkCore;
using MyCarStatistics.Contracts;
using MyCarStatistics.Data;
using MyCarStatistics.Data.Models;
using MyCarStatistics.Models;

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

        public Task Delete(string carId)
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

        public async Task  ImportCars()
        {
          
        }        
    }
}
