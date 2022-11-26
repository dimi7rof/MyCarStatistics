using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MyCarStatistics.Data.Models.Account
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(20)]
        public string? FirstName { get; set; }

        [StringLength(20)]
        public string? LastName { get; set; }

        public bool IsDeleted { get; set; } = false;

        public List<Car> Cars { get; set; } = new List<Car>();

    }
}
