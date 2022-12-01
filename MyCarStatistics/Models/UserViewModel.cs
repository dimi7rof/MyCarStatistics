using System.ComponentModel.DataAnnotations;

namespace MyCarStatistics.Models
{
    public class UserViewModel
    {
        public string Id { get; set; } = null!;

        public string UserName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? FirstName { get; set; }
               
        public string? LastName { get; set; }

        public bool IsAdmin { get; set; }

    }
}
