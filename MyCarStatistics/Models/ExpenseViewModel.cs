using MyCarStatistics.Common;
using System.ComponentModel.DataAnnotations;

namespace MyCarStatistics.Models
{
    public class ExpenseViewModel : BaseCarInfoVM
    {       
        public decimal Cost { get; set; }

        public decimal? Trip { get; set; }

        [StringLength(EntityConstants.ExpenseDescriptionStringLenght)]
        public string Description { get; set; } = null!;

        public int CarId { get; set; }

        public DateTime Date { get; set; }
    }
}
