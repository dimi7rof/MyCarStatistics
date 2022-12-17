using System.ComponentModel.DataAnnotations;

namespace MyCarStatistics.Models
{
    public class CarViewModel : BaseCarInfoVM
    {               
        public decimal? Spend { get; set; }
        public decimal? Earned { get; set; }
        public string? User { get; set; }
        public bool IsDeleted { get; set; }
    }
}
