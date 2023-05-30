using PS.AZ.EmpFunctionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.AZ.EmpFunctionApp.Repo
{
    public interface IEmployeeRepo
    {
        Task CreateEmployee(Employee employee);
        Task<List<Employee>> GetEmployees();
    }
}
