using System.ComponentModel.DataAnnotations;

namespace MyCarStatistics.Data.Models
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }

        public string BrandName { get; set; } = null!;

        public string? Url { get; set; }

        public string? Logo { get; set; }
                
    }
}
