using System.ComponentModel.DataAnnotations;

namespace MyCarStatistics.Models
{
    public class CarViewModel
    {
        [Required]
        public string Brand { get; set; } = null!;

        [Required]
        public string CarModel { get; set; } = null!;

        public decimal? Mileage { get; set; }
    }
}
