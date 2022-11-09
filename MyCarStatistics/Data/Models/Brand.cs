using System.ComponentModel.DataAnnotations;

namespace MyCarStatistics.Data.Models
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }

        public string BrandName { get; set; } = null!;

        public List<CarModel> CarModels { get; set; } = new List<CarModel>();

    }
}
