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
            services.AddScoped<IRefuelService, RefuelService>();
            services.AddScoped<IExpenseService, ExpenseService>();
            services.AddScoped<IIncomeService, IncomeService>();
            services.AddScoped<IServiceService, ServiceService>();
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IRepository, Repository>();

            return services;
        }
    }
}
