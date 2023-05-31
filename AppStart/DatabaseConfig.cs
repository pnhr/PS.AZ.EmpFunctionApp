using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PS.AZ.EmpFunctionApp.Repo.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.AZ.EmpFunctionApp.AppStart
{
    public static class DatabaseConfig
    {
        public static IFunctionsHostBuilder AddSqlServerDatabase(this IFunctionsHostBuilder builder)
        {
            string connStr = "Server=tcp:psnaz.database.windows.net,1433;Initial Catalog=psn;Persist Security Info=False;User ID=psn;Password=MySelf@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            builder.Services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(connStr));
            return builder;
        }
    }
}
