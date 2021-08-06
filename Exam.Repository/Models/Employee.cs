using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Repository.Models
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }
}
