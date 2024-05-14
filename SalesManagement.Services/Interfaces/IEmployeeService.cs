using SalesManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<bool> CreateEmployee(Employee employee);

        Task<IEnumerable<Employee>> GetAllEmployees();

        Task<Employee> GetEmployeeById(int employeeId);

        Task<bool> UpdateEmployee(Employee employee);

        Task<bool> DeleteEmployee(int employeeId);
    }
}
