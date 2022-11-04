using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCarStatistics.Data.Models
{
    public class CarModel
    {
        [Key]
        public int Id { get; set; }
        public string ModelName { get; set; } = null!;

        public int BrandId { get; set; }

        [ForeignKey(nameof(BrandId))]
        public Brand Brand { get; set; } = null!;
    }
}
