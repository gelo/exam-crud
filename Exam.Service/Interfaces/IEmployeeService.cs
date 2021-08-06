using Exam.Repository.Models;
using Exam.Service.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Service.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllEmployeeAsync();
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<Employee> AddEmployeeAsync(EmployeeDTO employee);
        Task<Employee> UpdateEmployeeAsync(EmployeeDTO employee);
        Task<Employee> DeleteEmployeeByIdAsync(int id);
    }
}
