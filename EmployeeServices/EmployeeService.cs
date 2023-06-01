using PS.AZ.EmpFunctionApp.Models;
using PS.AZ.EmpFunctionApp.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.AZ.EmpFunctionApp.EmployeeServices
{
    public class EmployeeService
    {
        private readonly IEmployeeRepo _empRepo;
        public EmployeeService(IEmployeeRepo repo)
        {
            this._empRepo = repo;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            List<Employee> employees = await _empRepo.GetEmployees();
            return employees.OrderByDescending(x => x.EmployeeId).ToList();
        }

        public async Task<Employee> GetEmployeeById(int empId)
        {
            Employee employee = await _empRepo.GetEmployeeById(empId);
            return employee;
        }

        public async Task CreateEmployee(Employee emp)
        {
            if(string.IsNullOrEmpty(emp.ImagePath))
            {
                emp.ImagePath = "/images/ps_default.png";
            }
            await _empRepo.CreateEmployee(emp);
        }
    }
}
