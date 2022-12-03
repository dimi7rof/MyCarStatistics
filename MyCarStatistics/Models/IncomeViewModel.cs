using MyCarStatistics.Common;
using System.ComponentModel.DataAnnotations;

namespace MyCarStatistics.Models
{
    public class IncomeViewModel : BaseCarInfoVM
    {
        public decimal MoneyEarned { get; set; }

        [StringLength(EntityConstants.IncomeDescriptionStringLenght)]
        public string Description { get; set; } = null!;

        public DateTime Date { get; set; }

        public int CarId { get; set; }
    }
}
