using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyCarStatistics.Data.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }

        public decimal Cost { get; set; }

        public decimal? Trip { get; set; }

        [StringLength(50)]
        public string? Description { get; set; }

        public DateTime Date { get; set; }

        public bool IsDeleted { get; set; }

        [Required]
        [ForeignKey(nameof(Car))]
        public int CarId { get; set; }
        public Car Car { get; set; } = null!;
    }
}
