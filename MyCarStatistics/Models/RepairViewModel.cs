using MyCarStatistics.Common;
using System.ComponentModel.DataAnnotations;

namespace MyCarStatistics.Models
{
    public class RepairViewModel : BaseCarInfoVM
    {       
        public decimal Cost { get; set; }

        public decimal? CurrentMillage { get; set; }

        [StringLength(EntityConstants.ServiceDescriptionStringLenght)]
        public string? Description { get; set; }

        public DateTime Date { get; set; }

        public int CarId { get; set; }
    }
}
