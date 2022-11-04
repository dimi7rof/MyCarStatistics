using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyCarStatistics.Data.Models;
using MyCarStatistics.Data.Models.Account;

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
            //modelBuilder.Entity<CarModel>()
            //     .HasOne<Brand>(b => b.Brand)
            //     .WithMany(m => m.Models)
            //     .HasForeignKey(b => b.BrandId);

            //modelBuilder.Entity<Brand>()
            //    .HasData( new Brand()
            //    { 
            //        Id = 1,
            //        BrandName = "Peugeot",
            //        Models = new List<CarModel>()
            //        {
            //            new CarModel()
            //            {
            //                ModelName =  "1007"
            //            }
            //        }
            //    });


            base.OnModelCreating(modelBuilder);
        }
    }
}