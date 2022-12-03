using MyCarStatistics.Common;
using System.ComponentModel.DataAnnotations;

namespace MyCarStatistics.Models
{
    public class BaseCarInfoVM
    {
        public int Id { get; set; }

        [StringLength(EntityConstants.CarBrandStringLenght)]
        public string? Brand { get; set; }

        [StringLength(EntityConstants.CarModelStringLenght)]
        public string? CarModel { get; set; }

        public decimal? Mileage { get; set; }
    }
}
