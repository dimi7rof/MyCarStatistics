using System.ComponentModel.DataAnnotations;

namespace MyCarStatistics.Models
{
    public class CarViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Brand { get; set; } = null!;
        [Required]
        public string CarModel { get; set; } = null!;
        public decimal? Mileage { get; set; }
        public decimal? Spend { get; set; }
        public decimal? Earned { get; set; }
        public string? User { get; set; }
    }
}
