using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PS.AZ.EmpFunctionApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace PS.AZ.EmpFunctionApp
{
    public static class EmployeeFunction
    {
        [FunctionName("GetEmployee")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            int.TryParse(req.Query["empId"],out int empId);

            string responseMessage = $"Hi User, We got the employee id \"{empId}\" from you!";
            return new OkObjectResult(responseMessage);
        }

        [FunctionName("SaveEmployee")]
        public static async Task<IActionResult> SaveEmployee(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            int.TryParse(req.Query["empId"], out int empId);

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            List<Employee> employees = JsonConvert.DeserializeObject<List<Employee>>(requestBody);

            Employee emp = employees.FirstOrDefault(x => x.EmployeeId == empId);

            string responseMessage = "-No Name-";

            if (emp != null)
            {
                responseMessage = $"{emp.FirstName} {emp.LastName}";
            }

            return new OkObjectResult(responseMessage);
        }
    }
}
