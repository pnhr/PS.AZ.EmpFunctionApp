using PS.AZ.EmpFunctionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.AZ.EmpFunctionApp.Repo
{
    public class EmployeeRepo : IEmployeeRepo
    {
        public async Task<List<Employee>> GetEmployees()
        {
            List<Employee> employees = GetTestData();
            return await Task.FromResult(employees);
        }

        public async Task CreateEmployee(Employee employee)
        {
            await Task.FromResult(0);
        }


        private List<Employee> GetTestData()
        {
            var employees = new List<Employee>();
            employees.Add(new Employee() { EmployeeId = 1, FirstName = "Padmasekhar", LastName = "Pottepalem" });
            employees.Add(new Employee() { EmployeeId = 2, FirstName = "Jeevan", LastName = "Punagala" });
            employees.Add(new Employee() { EmployeeId = 3, FirstName = "Prudhvi", LastName = "raj" });
            employees.Add(new Employee() { EmployeeId = 4, FirstName = "Sravya", LastName = "punagala" });
            employees.Add(new Employee() { EmployeeId = 5, FirstName = "Ravi", LastName = "varma" });
            return employees;
        }
    }
}
