using MyCarStatistics.Common;
using System.ComponentModel.DataAnnotations;

namespace MyCarStatistics.Models
{
    public class RefuelViewModel : BaseCarInfoVM
    {
        public decimal Liters { get; set; }

        public decimal Cost { get; set; }

        public decimal Trip { get; set; }

        [StringLength(EntityConstants.GasStationStringLenght)]
        public string? GasStation { get; set; }

        public int CarId { get; set; }

        public DateTime Date { get; set; }
    }
}
