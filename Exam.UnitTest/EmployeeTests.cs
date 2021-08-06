using Exam.Api.Models;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace ASPNetCoreMasterProject.UnitTest
{
    public class EmployeeTests
    {
        [Fact]
        public void CreateEmployeeRequest_Succeed()
        {
            var request = new CreateEmployeeRequest()
            {
                FirstName = "FirstName",
                LastName = "LastName",
                MiddleName = "MiddleName"
            };

            var actual = Validator.TryValidateObject(request, new ValidationContext(request), null, true);

            // Assert
            Assert.True(actual);
        }

        [Fact]
        public void FirstName_Invalid()
        {
            var request = new CreateEmployeeRequest()
            {
                FirstName = "FirstNameFirstNameFirstNameFirstNameFirstNameFirstNameFirstName",
                LastName = "LastName",
                MiddleName = "MiddleName"
            };

            var actual = Validator.TryValidateObject(request, new ValidationContext(request), null, true);

            // Assert
            Assert.False(actual, "First Name length should be no longer than 50.");
        }

        [Fact]
        public void LastName_Invalid()
        {
            var request = new CreateEmployeeRequest()
            {
                FirstName = "FirstName",
                LastName = "LastNameLastNameLastNameLastNameLastNameLastNameLastNameLastName",
                MiddleName = "MiddleName"
            };

            var actual = Validator.TryValidateObject(request, new ValidationContext(request), null, true);

            // Assert
            Assert.False(actual, "Last Name length should be no longer than 50.");
        }
    }
}
