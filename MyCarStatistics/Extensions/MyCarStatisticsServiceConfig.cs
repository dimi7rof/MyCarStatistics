using MyCarStatistics.Contracts;
using MyCarStatistics.Repositories;
using MyCarStatistics.Services;
using System;

namespace MyCarStatistics.Extensions
{
    public static class MyCarStatisticsServiceConfig
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IExpenseService, ExpenseService>();
            services.AddScoped<IIncomeService, IncomeService>();
            services.AddScoped<IRefuelService, RefuelService>();
            services.AddScoped<IServiceService, ServiceService>();

            return services;
        }
    }
}
