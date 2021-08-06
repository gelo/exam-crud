using Exam.Repository.Interfaces;
using Exam.Repository.Models;
using Exam.Service.DTO;
using Exam.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exam.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<Employee>> GetAllEmployeeAsync()
        {
            var result = await _employeeRepository.GetAllEmployeeRecords();
            return result;
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _employeeRepository.GetEmployeeByIdAsync(id);
        }

        public async Task<Employee> AddEmployeeAsync(EmployeeDTO employee)
        {
            Employee employeeDb = new Employee()
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                MiddleName = employee.MiddleName,
                LastName = employee.LastName
            };
            return await _employeeRepository.AddAsync(employeeDb);
        }

        public async Task<Employee> UpdateEmployeeAsync(EmployeeDTO employee)
        {
            Employee employeeDb = new Employee()
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                MiddleName = employee.MiddleName,
                LastName = employee.LastName
            };
            return await _employeeRepository.UpdateAsync(employeeDb);
        }
        public async Task<Employee> DeleteEmployeeByIdAsync(int id)
        {
            return await _employeeRepository.DeleteAsync(id);
        }
    }
}
