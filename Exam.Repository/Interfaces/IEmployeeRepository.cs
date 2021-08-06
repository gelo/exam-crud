using Exam.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Repository.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<List<Employee>> GetAllEmployeeRecords();
        Task<Employee> GetEmployeeByIdAsync(int id);
    }
}
