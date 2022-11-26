using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MyCarStatistics.Data.Configuration
{
    public class UserConfig
    {
        public class UserConfiguration : IEntityTypeConfiguration<IdentityUser>
        {
            public void Configure(EntityTypeBuilder<IdentityUser> builder)
            {
                builder.HasData(CreateUsers());
            }

            private List<IdentityUser> CreateUsers()
            {
                var users = new List<IdentityUser>();
                var hasher = new PasswordHasher<IdentityUser>();

                var user = new IdentityUser()
                {
                    Id = "f17630b5-b82d-478f-9506-196465ebd587",
                    UserName = "User4",
                    NormalizedUserName = "USER4",
                    Email = "user4@abv.bg",
                    NormalizedEmail = "USER4@ABV.BG"
                };

                user.PasswordHash =
                     hasher.HashPassword(user, "User4!");

                users.Add(user);

                user = new IdentityUser()
                {
                    Id = "g17630b5-b82d-478f-9506-196465ebd587",
                    UserName = "User5",
                    NormalizedUserName = "USER5",
                    Email = "user5@abv.bg",
                    NormalizedEmail = "USER5@ABV.BG"
                };

                user.PasswordHash =
                     hasher.HashPassword(user, "User5!");

                users.Add(user);

                return users;
            }

        }
    }
}
