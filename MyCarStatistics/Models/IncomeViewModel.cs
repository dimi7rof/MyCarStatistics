using MyCarStatistics.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCarStatistics.Models
{
    public class IncomeViewModel
    {
        public int Id { get; set; }

        public string? Brand { get; set; }

        public string? CarModel { get; set; }

        public decimal MoneyEarned { get; set; }

        public string? Description { get; set; }

        public DateTime Date { get; set; }

        public int CarId { get; set; }
    }
}
