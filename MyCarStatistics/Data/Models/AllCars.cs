using System.ComponentModel.DataAnnotations;

namespace MyCarStatistics.Data.Models
{
    public class AllCars
    {
        [Key]
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Models { get; set; }
    }
}
