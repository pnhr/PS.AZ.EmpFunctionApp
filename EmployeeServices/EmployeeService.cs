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
        public EmployeeService():this(new EmployeeRepo())
        {

        }
        public EmployeeService(IEmployeeRepo repo)
        {
            this._empRepo = repo;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            List<Employee> employees = await _empRepo.GetEmployees();
            return employees;
        }

        public async Task<Employee> GetEmployeeById(int empId)
        {
            List<Employee> employees = await _empRepo.GetEmployees();
            return employees?.FirstOrDefault(x=> x.EmployeeId == empId);
        }

        public async Task CreateEmployee(Employee employee)
        {
            await _empRepo.CreateEmployee(employee);
        }
    }
}
