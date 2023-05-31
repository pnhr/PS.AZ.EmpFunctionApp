using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using PS.AZ.EmpFunctionApp.AppStart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: FunctionsStartup(typeof(PS.AZ.EmpFunctionApp.Startup))]
namespace PS.AZ.EmpFunctionApp
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.AddSqlServerDatabase();
            builder.AddAppServices();
        }
    }
}
