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
        [StringLength(50)]
        public string Brand { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string CarModel { get; set; } = null!;

        public decimal? Mileage { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;

        public ApplicationUser User { get; set; } = null!;

        public List<Refuel> Refuels { get; set; } = new List<Refuel>();
        public List<Expense> Expenses { get; set; } = new List<Expense>();
        public List<Income> Incomes { get; set; } = new List<Income>();
        public List<Service> Services { get; set; } = new List<Service>();
    }
}
