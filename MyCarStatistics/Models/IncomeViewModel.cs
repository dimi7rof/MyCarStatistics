namespace MyCarStatistics.Models
{
    public class IncomeViewModel
    {
        public int Id { get; set; }
        public string? Brand { get; set; }
        public string? CarModel { get; set; }
        public decimal MoneyEarned { get; set; }
        public string Description { get; set; } = null!;
        public DateTime Date { get; set; }
        public int CarId { get; set; }
    }
}
