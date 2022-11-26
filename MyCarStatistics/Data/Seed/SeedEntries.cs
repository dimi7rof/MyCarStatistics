using MyCarStatistics.Models;

namespace MyCarStatistics.Data.Seed
{
    public static class SeedEntries
    {
        public static List<RegisterViewModel> SeedUsers()
        { 
            List<RegisterViewModel> users = new List<RegisterViewModel>();
            RegisterViewModel user1 = new RegisterViewModel()
            { 
                UserName = "user01",
                Email = "user01@abv.bg",
                Password = "User01!"
            };
            users.Add(user1);
            RegisterViewModel user2 = new RegisterViewModel()
            {
                UserName = "user02",
                Email = "user02@abv.bg",
                Password = "User02!"
            };
            users.Add(user2);
            RegisterViewModel user3 = new RegisterViewModel()
            {
                UserName = "user03",
                Email = "user03@abv.bg",
                Password = "User03!"
            };
            users.Add(user3);   
            RegisterViewModel user4 = new RegisterViewModel()
            {
                UserName = "admin",
                Email = "admin@abv.bg",
                Password = "Admin1!"
            };
            users.Add(user4);
            return users;
        }        
    }
}
