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
            return employees.OrderByDescending(x => x.EmployeeId).ToList();
        }

        public async Task<Employee> GetEmployeeById(int empId)
        {
            List<Employee> employees = await _empRepo.GetEmployees();
            var emp = employees?.FirstOrDefault(x=> x.EmployeeId == empId);
            return emp;
        }

        public async Task<List<Employee>> CreateEmployee(List<Employee> newEmployees)
        {
            int id = (await _empRepo.GetEmployees())?.Count ?? 0;
            foreach (var emp in newEmployees)
            {
                emp.EmployeeId = ++id;
                await _empRepo.CreateEmployee(emp);
            }
            List<Employee> employees = await _empRepo.GetEmployees();
            return employees.OrderByDescending(x => x.EmployeeId).ToList();
        }
    }
}
