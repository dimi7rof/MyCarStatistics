namespace MyCarStatistics.Models
{
    public class RefuelViewModel
    {
        public int Id { get; set; }
        public string? Brand { get; set; }
        public string? CarModel { get; set; }
        public decimal Liters { get; set; }
        public decimal Cost { get; set; }
        public decimal Trip { get; set; }
        public string? GasStation { get; set; }
        public int CarId { get; set; }
        public DateTime Date { get; set; }
    }
}
