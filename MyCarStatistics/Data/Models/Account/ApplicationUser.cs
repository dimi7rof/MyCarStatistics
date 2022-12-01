using Microsoft.AspNetCore.Identity;
using MyCarStatistics.Common;
using System.ComponentModel.DataAnnotations;

namespace MyCarStatistics.Data.Models.Account
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(EntityConstants.UserFirstNameStringLenght)]
        public string? FirstName { get; set; }

        [StringLength(EntityConstants.UserLastNameStringLenght)]
        public string? LastName { get; set; }

        public bool IsDeleted { get; set; } = false;

        public List<Car> Cars { get; set; } = new List<Car>();

    }
}
