using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using PS.AZ.EmpFunctionApp.EmployeeServices;
using PS.AZ.EmpFunctionApp.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.AZ.EmpFunctionApp.AppStart
{
    public static class ObjectContainer
    {
        public static IServiceCollection AddApplicationObjects(this IServiceCollection services)
        {
            services.AddRepoDependencies();
            return services;
        }
        private static void AddRepoDependencies(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepo, EmployeeRepo>();
            services.AddScoped<EmployeeService>();
        }
    }
}
