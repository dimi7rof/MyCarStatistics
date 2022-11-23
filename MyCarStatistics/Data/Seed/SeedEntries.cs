using MyCarStatistics.Controllers;
using MyCarStatistics.Data.Models;
using MyCarStatistics.Data.Models.Account;
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
            return users;
        }

        //public static List<Car> SeedCars(string userID)
        //{
        //    List<Car> list = new List<Car>();
        //    var car = new Car()
        //    {
        //        Brand = "Alfa",
        //        CarModel = "147",
        //        CreatedOn = DateTime.Now,
        //        IsDeleted = false,
        //        Mileage = 0,
        //        UserId = userID
        //    };
        //    list.Add(car);
        //    return list;
        //}
    }
}
