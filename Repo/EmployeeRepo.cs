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
        private List<Employee> _employees = new List<Employee>();
        public async Task<List<Employee>> GetEmployees()
        {
            if (_employees.Count == 0)
                GetTestData();
            return await Task.FromResult(_employees);
        }

        public async Task CreateEmployee(Employee employee)
        {
            if (_employees.Count == 0)
                GetTestData();
            else
                _employees.Add(employee);
            await Task.FromResult(0);
        }


        private void GetTestData()
        {
            _employees.Add(new Employee() { EmployeeId = 1, FirstName = "Padmasekhar", LastName = "Pottepalem" });
            _employees.Add(new Employee() { EmployeeId = 2, FirstName = "Jeevan", LastName = "Punagala" });
            _employees.Add(new Employee() { EmployeeId = 3, FirstName = "Prudhvi", LastName = "raj" });
            _employees.Add(new Employee() { EmployeeId = 4, FirstName = "Sravya", LastName = "punagala" });
            _employees.Add(new Employee() { EmployeeId = 5, FirstName = "Ravi", LastName = "varma" });
        }
    }
}
