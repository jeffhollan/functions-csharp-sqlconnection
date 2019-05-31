using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

[assembly: FunctionsStartup(typeof(functions_csharp_sqlconnection.Startup))]

namespace functions_csharp_sqlconnection
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<SqlConnection>((s) =>
            {
                var log = s.GetService<ILoggerFactory>().CreateLogger("Startup");
                log.LogInformation("Got here");
                string connectionString = Environment.GetEnvironmentVariable("SqlConnectionString");
                var conn = new SqlConnection(connectionString);
                conn.Open();
                return conn;
            });
        }
    }
}
