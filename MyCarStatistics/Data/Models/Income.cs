using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MyCarStatistics.Common;

namespace MyCarStatistics.Data.Models
{
    public class Income
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public decimal Earned { get; set; }

        [StringLength(EntityConstants.IncomeDescriptionStringLenght)]
        public string Description { get; set; } = null!;

        public DateTime Date { get; set; }

        public bool IsDeleted { get; set; }

        [Required]
        [ForeignKey(nameof(Car))]
        public int CarId { get; set; }
        public Car Car { get; set; } = null!;
    }
}
