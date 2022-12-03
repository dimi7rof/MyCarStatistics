namespace MyCarStatistics.Models
{
    public class RepairViewModel
    {
        public int Id { get; set; }
        public string? Brand { get; set; }
        public string? CarModel { get; set; }
        public decimal Cost { get; set; }
        public decimal? CurrentMillage { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public int CarId { get; set; }
    }
}
