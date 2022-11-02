using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MyCarStatistics.Data.Models.Account;

namespace MyCarStatistics.Data.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Brand { get; set; } = null!;

        [Required]
        public string CarModel { get; set; } = null!;

        public decimal? Mileage { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string? UserId { get; set; }

        public ApplicationUser? User { get; set; } 

        public ICollection<Refuel> Refuels { get; set; } = new List<Refuel>();
        public ICollection<Expense> Expenses { get; set; } = new List<Expense>();
        public ICollection<Income> Incomes { get; set; } = new List<Income>();
        public ICollection<Service> Services { get; set; } = new List<Service>();
    }
}
