using System.ComponentModel.DataAnnotations;

namespace MyCarStatistics.Models
{
    public class RefuelViewModel
    {
        [Required]
        public decimal Liters { get; set; }

        public decimal Cost { get; set; }

        public decimal DrivenKm { get; set; }

        public string? GasStation { get; set; }

        public bool IsDeleted { get; set; }
    }
}
