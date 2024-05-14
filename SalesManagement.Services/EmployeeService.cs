using SalesManagement.Core.Interfaces;
using SalesManagement.Core.Models;
using SalesManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.Services
{
    public class EmployeeService : IEmployeeService
    {
        public IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateEmployee(Employee employee)
        {
            if (employee != null)
            {
                await _unitOfWork.Employees.Add(employee);

                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteEmployee(int employeeId)
        {
            if (employeeId > 0)
            {
                var employee = await _unitOfWork.Employees.GetById(employeeId);
                if (employee != null)
                {
                    _unitOfWork.Employees.Delete(employee);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            var employeeList = await _unitOfWork.Employees.GetAll();
            return employeeList;
        }

        public async Task<Employee> GetEmployeeById(int employeeId)
        {
            if (employeeId > 0)
            {
                var employee = await _unitOfWork.Employees.GetById(employeeId);
                if (employee != null)
                {
                    return employee;
                }
            }
            return null;
        }

        public async Task<bool> UpdateEmployee(Employee employee)
        {
            if (employee != null)
            {
                var employeeFind = await _unitOfWork.Employees.GetById(employee.EmployeeId);
                if (employeeFind != null)
                {
                    employeeFind.EmployeeName = employee.EmployeeName;
                    employeeFind.State = employee.State;
                    employeeFind.Address = employee.Address;
                    employeeFind.PhoneNumber = employee.PhoneNumber;
                    employeeFind.EmailAddress = employee.EmailAddress;
                    employeeFind.City = employee.City;
                    employeeFind.Country = employee.Country;
                    employeeFind.Designation = employee.Designation;
                    employeeFind.Gender = employee.Gender;
                    employeeFind.PostalCode = employee.PostalCode;


                    _unitOfWork.Employees.Update(employeeFind);

                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }
    }
}
