﻿using MyCarStatistics.Data.Models.Account;
using MyCarStatistics.Models;

namespace MyCarStatistics.Contracts
{
    public interface IAdminService
    {
        Task<IEnumerable<UserViewModel>> GetAllUsers();

        Task<IEnumerable<CarViewModel>> GetAllCars();
    }
}
