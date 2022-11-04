using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyCarStatistics.Data.Models;
using MyCarStatistics.Data.Models.Account;
using MyCarStatistics.Models;
using Newtonsoft.Json;
using System.Text;

namespace MyCarStatistics.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; } = null!;
        public DbSet<Refuel> Refuels { get; set; } = null!;
        public DbSet<Expense> Expenses { get; set; } = null!;
        public DbSet<Income> Incomes { get; set; } = null!;
        public DbSet<Service> Services { get; set; } = null!;
        public DbSet<Brand> Brands { get; set; } = null!;
        public DbSet<CarModel> CarModels { get; set; } = null!;



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Brand>()
            //    .HasData(new Brand()
            //    {
            //        Id = 1,
            //        BrandName = "Peugeot"                    
            //    });
            //modelBuilder.Entity<CarModel>()
            //    .HasData( new CarModel()
            //    { 
            //        Id = 1,
            //        ModelName = "206",
            //        BrandId = 1
            //    });
            
            base.OnModelCreating(modelBuilder);
        }
       
    }
}