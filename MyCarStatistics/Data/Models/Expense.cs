using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyCarStatistics.Data.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }

        public decimal? Cost { get; set; }

        public decimal? CurrentKm { get; set; }

        public string? Description { get; set; }

        public DateTime Date { get; set; }

        public bool IsDeleted { get; set; }

        [Required]
        [ForeignKey(nameof(Car))]
        public int CarId { get; set; }
        public virtual Car? Car { get; set; }
    }
}
