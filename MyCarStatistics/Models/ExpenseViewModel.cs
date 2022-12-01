using Microsoft.CodeAnalysis.VisualBasic.Syntax;

namespace MyCarStatistics.Models
{
    public class ExpenseViewModel
    {
        public int Id { get; set; }
        public string? Brand { get; set; }

        public string? CarModel { get; set; }

        public decimal Cost { get; set; }

        public decimal? Trip { get; set; }

        public string Description { get; set; } = null!;

        public int CarId { get; set; }

        public DateTime Date { get; set; }
    }
}
