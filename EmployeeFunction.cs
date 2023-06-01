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
using PS.AZ.EmpFunctionApp.EmployeeServices;
using System.Web.Http;

namespace PS.AZ.EmpFunctionApp
{
    public class EmployeeFunction
    {
        private readonly EmployeeService _empService;
        public EmployeeFunction(EmployeeService empService)
        {
            _empService = empService;
        }
        [FunctionName("GetEmployee")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            try
            {
                log.LogInformation("GetEmployee function have been called");
                var employees = await _empService.GetEmployees();
                return new OkObjectResult(employees);
            }
            catch(Exception ex)
            {
                return new InternalServerErrorResult();
            }
            
        }

        [FunctionName("GetEmployeeById")]
        public async Task<IActionResult> GetEmployeesById(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            try
            {
                log.LogInformation("GetEmployeeById function have been called");
                int.TryParse(req.Query["empId"], out int empId);
                var employee = await _empService.GetEmployeeById(empId);
                if (employee == null)
                    return new NotFoundResult();
                else
                    return new OkObjectResult(employee);
            }
            catch (Exception ex)
            {
                return new InternalServerErrorResult();
            }
        }

        [FunctionName("SaveEmployee")]
        public async Task<IActionResult> SaveEmployee(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("SaveEmployee function have been called");
            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                Employee employee = JsonConvert.DeserializeObject<Employee>(requestBody);
                await _empService.CreateEmployee(employee);
                return new OkObjectResult(employee);
            }
            catch (Exception ex)
            {
                return new InternalServerErrorResult();
            }
        }

        [FunctionName("DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(
            [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("DeleteEmployee function have been called");
            try
            {
                int.TryParse(req.Query["empId"], out int empId);

                await _empService.DeleteEmployee(empId);
                return new OkResult();
            }
            catch (Exception ex)
            {
                return new InternalServerErrorResult();
            }
        }
    }
}
