using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyCarStatistics.Data.Models
{
    public class Refuel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public decimal Liters { get; set; }

        public decimal? Cost { get; set; }

        public decimal? DrivenKm { get; set; }

        public string? GasStation { get; set; }

        public DateTime Date { get; set; }

        public bool IsDeleted { get; set; }

        [Required]
        [ForeignKey(nameof(Car))]
        public int CarId { get; set; }
        public Car Car { get; set; } = null!;
    }
}
