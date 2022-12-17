using System.ComponentModel.DataAnnotations;

namespace MyCarStatistics.Models
{
    public class OverviewModel : BaseCarInfoVM
    {
        public int? Refuels { get; set; }
        public decimal? TotalLiters { get; set; }
        public decimal? TotalCostRefuels { get; set; }
        public decimal? TotalCostExpenses { get; set; }
        public decimal? TotalCostRepairs { get; set; }
        public decimal? MoneyEarned { get; set; }        
    }
}
