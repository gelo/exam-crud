using Exam.Repository.Interfaces;
using Exam.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }

        public Task<List<Employee>> GetAllEmployeeRecords()
        {
            return GetAll().ToListAsync();
        }

        public Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return GetAll().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
