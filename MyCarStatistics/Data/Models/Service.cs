using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MyCarStatistics.Common;

namespace MyCarStatistics.Data.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }

        public decimal Cost { get; set; }

        public decimal? CurrentKm { get; set; }

        [StringLength(EntityConstants.ServiceDescriptionStringLenght)]
        public string? Description { get; set; }

        public DateTime Date { get; set; }

        public bool IsDeleted { get; set; }

        [Required]
        [ForeignKey(nameof(Car))]
        public int CarId { get; set; }
        public Car Car { get; set; } = null!;
    }
}
