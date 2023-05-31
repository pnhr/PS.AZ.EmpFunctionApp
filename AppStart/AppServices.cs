using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.AZ.EmpFunctionApp.AppStart
{
    public static class AppServices
    {
        public static IFunctionsHostBuilder AddAppServices(this IFunctionsHostBuilder builder)
        {
            builder.Services.AddApplicationObjects();
            return builder;
        }
    }
}
