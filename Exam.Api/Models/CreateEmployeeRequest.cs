using Exam.Api.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.Api.Models
{
    public class CreateEmployeeRequest
    {
        [Required]
        [NameValidation]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        [NameValidation]
        public string LastName { get; set; }
    }
}
