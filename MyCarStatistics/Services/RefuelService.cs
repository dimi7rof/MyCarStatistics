using MyCarStatistics.Contracts;
using MyCarStatistics.Data;
using MyCarStatistics.Data.Models;
using MyCarStatistics.Models;

namespace MyCarStatistics.Services
{
    public class RefuelService : IRefuelService
    {
        private readonly ApplicationDbContext context;

        public RefuelService(ApplicationDbContext _context)
        {
            context = _context;
        }
        
        public Task Delete(string carId)
        {
            throw new NotImplementedException();
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
    }
}
