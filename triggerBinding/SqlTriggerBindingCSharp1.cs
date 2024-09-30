using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.Functions.Worker.Extensions.Sql;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Company.Function
{
    public class SqlTriggerBindingCSharp1
    {
        private readonly ILogger _logger;

        public SqlTriggerBindingCSharp1(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<SqlTriggerBindingCSharp1>();
        }

        // Visit https://aka.ms/sqltrigger to learn how to use this trigger binding
        [Function("SqlTriggerBindingCSharp1")]
        public void Run(
            [SqlTrigger("[dbo].[Person]", "connection-string")] IReadOnlyList<SqlChange<Person>> changes,
                FunctionContext context)
        {
            _logger.LogInformation("SQL Changes: " + JsonConvert.SerializeObject(changes));

        }
    }

    public class Person
{
    public int person_id { get; set; }
    public string person_name { get; set; }
    public string person_email { get; set; }      
    public string pet_preference { get; set; }
}
}
