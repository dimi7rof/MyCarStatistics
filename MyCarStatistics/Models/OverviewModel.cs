using System.ComponentModel.DataAnnotations;

namespace MyCarStatistics.Models
{
    public class OverviewModel
    {
        [Required]
        public int Id { get; set; }
        public string Brand { get; set; } = null!;       
        public string CarModel { get; set; } = null!;
        public decimal? Mileage { get; set; }
        public int? Refuels { get; set; }
        public decimal? TotalLiters { get; set; }
        public decimal? TotalCostRefuels { get; set; }
        public decimal? TotalCostExpenses { get; set; }
        public decimal? TotalCostServices { get; set; }
        public decimal? MoneyEarned { get; set; }        
    }
}
