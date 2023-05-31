using Microsoft.EntityFrameworkCore;
using PS.AZ.EmpFunctionApp.Models;
using PS.AZ.EmpFunctionApp.Repo.Database;
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
        private readonly AppDbContext _dbContext;

        public EmployeeRepo(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<List<Employee>> GetEmployees()
        {
            return await _dbContext.Employees.ToListAsync();
        }
        public async Task<Employee> GetEmployeeById(int empId)
        {
            Employee emp = await _dbContext.Employees.FindAsync(empId);
            return emp;
        }
        public async Task CreateEmployee(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            await _dbContext.SaveChangesAsync();
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
