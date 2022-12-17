using MyCarStatistics.Common;
using System.ComponentModel.DataAnnotations;

namespace MyCarStatistics.Models
{
    public class UserViewModel
    {
        public string Id { get; set; } = null!;

        public string UserName { get; set; } = null!;

        [EmailAddress]
        public string Email { get; set; } = null!;

        [StringLength(EntityConstants.UserFirstNameStringLenght)]
        public string? FirstName { get; set; }

        [StringLength(EntityConstants.UserLastNameStringLenght)]
        public string? LastName { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsDeleted { get; set; }

    }
}
