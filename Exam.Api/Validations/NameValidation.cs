using Exam.Api.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.Api.Validations
{
    public class NameValidationAttribute : ValidationAttribute
    {
       
        public string GetErrorMessage() =>
           "Name length should be no longer than 50.";

        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            var customer = (CreateEmployeeRequest)validationContext.ObjectInstance;
            if ((validationContext.DisplayName == "FirstName" && customer.FirstName.Length > 50) || (validationContext.DisplayName == "LastName" && customer.LastName.Length > 50))
            {
                return new ValidationResult(GetErrorMessage());
            }
            return ValidationResult.Success;
        }
    }
}
