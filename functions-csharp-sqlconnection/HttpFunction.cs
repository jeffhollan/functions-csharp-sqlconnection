using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Data.SqlClient;

namespace functions_csharp_sqlconnection
{

    public class HttpFunction
    {
        private readonly SqlConnection _sql;

        public HttpFunction(SqlConnection sql)
        {
            _sql = sql;
        }
    
            [FunctionName("HttpFunction")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var s = new SqlCommand("select * from foo", _sql);

            var r = await s.ExecuteReaderAsync();

            return new OkResult();
        }
    }
}
